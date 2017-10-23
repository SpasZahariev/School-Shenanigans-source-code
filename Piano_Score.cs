using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Piano_Score : MonoBehaviour {

    public int score;
    private Piano_Question ques;
    public GameObject FailScreen;
    private Piano_Button resetleft;
    private Piano_Button resetright;
    private int SaveScore;

    void Awake()
    {
        ques = FindObjectOfType<Piano_Question>();
        resetright = GameObject.Find("RightButton").GetComponent<Piano_Button>();
        resetleft = GameObject.Find("LeftButton").GetComponent<Piano_Button>();
    }

    public void UpdateScore(bool Correct)
    {
        if (Correct)
                score += 1;
        else
        {
            SaveScore = score;
            score = 0;
            StopGame();
        }

        gameObject.GetComponent<Text>().text = "Score: " + score;
    }
    public void StopGame()
    {
        ques.anim.SetBool("Playing", false);
        FailScreen.SetActive(true);
        FailScreen.transform.Find("Score").GetComponent<Text>().text = "Score: " + SaveScore;
        if (PlayerPrefs.GetInt("Piano") < SaveScore)
        {
            FailScreen.transform.Find("Record").GetComponent<Text>().text = "Record " + SaveScore;
            PlayerPrefs.SetInt("Piano", SaveScore);
        }
        else
            FailScreen.transform.Find("Record").GetComponent<Text>().text = "Record: " + PlayerPrefs.GetInt("Piano");

    }
    public void StartGame()
    {
        ques.anim.SetBool("Playing", true);
        FailScreen.SetActive(false);
        score = 0;
        resetleft.anim.SetInteger("IsCorrect", 0);
        resetright.anim.SetInteger("IsCorrect", 0);
    }
}
