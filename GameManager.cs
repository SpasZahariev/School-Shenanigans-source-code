using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    System.Random rand = new System.Random();

    public GameObject exit;

    public Sprite red;
    public Sprite green;
    public Sprite blue;
    public Sprite yellow;

    public float speedMinInSeconds = 0.5f;
    public float speedMaxInSeconds = 1.5f;

    public DColor[] colors;

    public int numberOfPlayToShowInterstitial = 20;

    public Text textScore;

    public Transform dotPrefab;

    int _point = 0;
    int point
    {
        get
        {
            return _point;
        }

        set
        {
            _point = value;

            textScore.text = _point.ToString();
        }
    }

    public CanvasGroup[] canvasGroups;

    [System.NonSerialized]
    public bool isGameOver = false;

    void Awake()
    {
        exit.SetActive(true);

        isGameOver = true;

        Application.targetFrameRate = 60;

        ResetUIElement();

        transform.position = Vector3.zero;
   
    }

    void ResetUIElement()
    {
        isGameOver = true;

        textScore.text = "TAP TO BEGIN";

        InputTouch.OnTouched += OnTouched;
    }

    void OnTouched(TouchDirection td)
    {
        isGameOver = true;
        
        DOStart();
    }

    public void DOStart()
    {
        
        isGameOver = false;

        InputTouch.OnTouched -= OnTouched;

        FindObjectOfType<Floor>().DOEnable();

        DOCreateDot();

        point = 0;

       
    }


    void DOCreateDot()
    {
        var inst = Instantiate(dotPrefab) as Transform;

        inst.parent = transform;

        inst.GetComponent<DBase>().SetColor(colors[rand.Next(0, colors.Length)]);

        inst.transform.position = new Vector3(FindObjectOfType<Floor>().GetPositionForDot(), 1.2f * Camera.main.orthographicSize, 0);

        Invoke("DOCreateDot", UnityEngine.Random.Range(speedMinInSeconds, speedMaxInSeconds));

    }

    public void GameOver()
    {
        exit.SetActive(true);

        isGameOver = true;

        FindObjectOfType<Floor>().DODisable();

        Utils.SetBest(point);

        var dots = FindObjectsOfType<Dot>();

        foreach (var d in dots)
        {
            if (d != null && d.gameObject != null)
                Destroy(d.gameObject);
        }

        CancelInvoke("DOCreateDot");

        textScore.text = "BEST " + Utils.GetBest();

        StartCoroutine(DelayTouch(1f));
    }


    public void Add1Point()
    {
        point++;
    }

    IEnumerator DelayTouch(float value)
    {
        yield return new WaitForSeconds(value);
        InputTouch.OnTouched += OnTouched;
    }

}
