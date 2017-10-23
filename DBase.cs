using UnityEngine;
using System.Collections;
using System;

public class DBase : MonoBehaviour 
{
	public DColor color;
    public Sprite sprite;

	[NonSerialized] public GameManager gm;

	[NonSerialized] public SpriteRenderer sr;

	[NonSerialized] public TrailRenderer tr;

	[NonSerialized] public Vector3 position;


	virtual public void Awake()
	{
		gm = FindObjectOfType<GameManager>();

		sr = GetComponent<SpriteRenderer>();

		tr = GetComponent<TrailRenderer>();
	}

	public virtual void SetColor(DColor c)
	{
		if(c == DColor.RED)
		{
			color = DColor.RED;

            sr.sprite = gm.red;
            sr.color = new Color(1, 1, 1);

        }
		else if(c == DColor.GREEN)
		{
			color = DColor.GREEN;

            sr.sprite = gm.green;
            sr.color = new Color(1, 1, 1);

        }
		else if(c == DColor.BLUE)
		{
			color = DColor.BLUE;

            sr.sprite = gm.blue;
            sr.color = new Color(1, 1, 1);

        }
		else if(c == DColor.YELLOW)
		{
			color = DColor.YELLOW;

            sr.sprite = gm.yellow;
            sr.color = new Color(1, 1, 1);

        }

		if(tr != null)
		{
            Color cc = sr.color;
            if (sr.sprite == gm.red)
            {
                cc = new Color(1, 0, 0);
            }
            if (sr.sprite == gm.green)
            {
                cc = new Color(0, 1, 0);
            }
            if (sr.sprite == gm.blue)
            {
                cc = new Color(0, 0, 1);
            }
            if (sr.sprite == gm.yellow)
            {
                cc = new Color(1, 0.92f, 0.016f);
            }
            cc.a = 0.3f;
			tr.material.SetColor("_TintColor", cc);
		}
		
	}
}
