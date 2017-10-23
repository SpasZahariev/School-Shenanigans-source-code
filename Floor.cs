using UnityEngine;
using System;
using System.Collections;

public class Floor : MonoBehaviour 
{
	public Transform floorCenter;
    public GameObject exit;

	[NonSerialized] public int number = 10;

	public float size = 1;

	System.Random rand = new System.Random();

	GameManager _gm;

	void Awake()
	{
		_gm = FindObjectOfType<GameManager>();

		transform.position = Vector3.zero;

		size = floorCenter.GetComponent<SpriteRenderer>().bounds.size.x;

		for(int i = - number; i <= number; i++)
		{
			Transform t = Instantiate(floorCenter) as Transform;
			t.parent = transform;
			var x = size * i;

			GameManager gm = FindObjectOfType<GameManager>();

			t.localPosition = new Vector3(x,0,0);
            t.GetComponent<DBase>().SetColor(gm.colors[(i + number + 1) % 4]);


            t.name = i.ToString();
		}

		for(int i = 0; i < transform.childCount; i++)
		{
			transform.SetSiblingIndex(i);
		}


		float height = 2f * Camera.main.orthographicSize;

		transform.position = Vector3.up * (-height / 3f);
	}

	public float GetPositionForDot()
	{
		int max = 4;

		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;

		if(4 * size > width / 2f)
		{
			max = 3;
		}
		float r = rand.Next(-max,max + 1);

		return r * size;
	}

	public void DOEnable()
	{
		InputTouch.OnTouched += OnTouched;
    }

	public void DODisable()
	{
		InputTouch.OnTouched -= OnTouched;
	}

	void OnTouched (TouchDirection td)
	{
		if(_gm.isGameOver)
			return;

        if (td == TouchDirection.none)
        {
            exit.SetActive(false);
            return;
        }
		if(td == TouchDirection.left)
			OnTouchLeft();
		else
			OnTouchRight();
	}

	void OnTouchLeft()
	{

		var t = transform.GetChild(0);

		DColor dc = transform.GetChild(transform.childCount - 1).GetComponent<DBase>().color;

		switch(dc)
		{
		case DColor.BLUE:
			t.GetComponent<DBase>().SetColor(DColor.GREEN);
			break;
		case DColor.GREEN:
			t.GetComponent<DBase>().SetColor(DColor.YELLOW);
			break;
		case DColor.YELLOW:
			t.GetComponent<DBase>().SetColor(DColor.RED);
			break;
		case DColor.RED:
			t.GetComponent<DBase>().SetColor(DColor.BLUE);
			break;
		default:
			Debug.LogError("error");
			break;
		}

		t.localPosition = transform.GetChild(transform.childCount - 1).localPosition;
		t.SetSiblingIndex(transform.childCount - 1);

		for(int i = 0; i < transform.childCount - 1; i++)
		{
			var tt = transform.GetChild(i);
            tt.localPosition = new Vector3(tt.localPosition.x - size, tt.localPosition.y, tt.localPosition.z);
        }
	}
		
	void OnTouchRight()
	{
		
		var t = transform.GetChild(transform.childCount - 1);

		DColor dc = transform.GetChild(0).GetComponent<DBase>().color;

		switch(dc)
		{
		case DColor.BLUE:
			t.GetComponent<DBase>().SetColor(DColor.RED);
			break;
		case DColor.RED:
			t.GetComponent<DBase>().SetColor(DColor.YELLOW);
			break;
		case DColor.YELLOW:
			t.GetComponent<DBase>().SetColor(DColor.GREEN);
			break;
		case DColor.GREEN:
			t.GetComponent<DBase>().SetColor(DColor.BLUE);
			break;
		default:
			Debug.LogError("error");
			break;
		}

		t.localPosition = transform.GetChild(0).localPosition;
		t.SetSiblingIndex(0);

		for(int i = 1; i < transform.childCount; i++)
		{
			var tt = transform.GetChild(i);
            tt.localPosition = new Vector3(tt.localPosition.x + size, tt.localPosition.y, tt.localPosition.z);
        }
	}

    void OnDestroy()
    {
        DODisable();
    }
}
