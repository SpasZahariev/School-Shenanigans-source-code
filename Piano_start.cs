using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Piano_start : MonoBehaviour {

    public Canvas FirstScreen;
    private GameObject Title;
    public GameObject Game;
    public GameObject Exit;
    public GameObject CD;
    private int CDnumber = 3;
    private int br = 0;


    void Awake()
    {
        Title = GameObject.Find("Title");
    }
    public void EnableCanvas()
    {
        FirstScreen.gameObject.SetActive(true);
    }
    public void DisableTitleAndButton()
    {
        Title.SetActive(false);
        CD.SetActive(true);
        gameObject.SetActive(false);
        Exit.SetActive(false);
    }
    public void CountDown ()
    {
        if (CDnumber - br == 1)
        {
            gameObject.SetActive(false);
            Game.SetActive(true);
        }
        br++;
        gameObject.GetComponent<Text>().text = "" + (CDnumber - br);

    }
        
}
