using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Piano_Question : MonoBehaviour {

    public int x;
    public int y;
    public int result;
    public int compare;
    private Text leftbutton;
    private Text rightbutton;
    private Piano_Button resetleft;
    private Piano_Button resetright;
    private float Difficulty;
    private Piano_Score score;
    public Animator anim;
    public bool IsPressed;
    private int Negative;

    void Awake()
    {
        leftbutton = GameObject.Find("LeftButton").GetComponentInChildren<Text>();
        resetleft = GameObject.Find("LeftButton").GetComponent<Piano_Button>();
        rightbutton = GameObject.Find("RightButton").GetComponentInChildren<Text>();
        resetright = GameObject.Find("RightButton").GetComponent<Piano_Button>();
        score = GameObject.Find("Score").GetComponent<Piano_Score>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void NewQuestion()
    {
        Difficulty = score.score + 1;
        Negative = Random.Range(1, 3);
        if (Negative == 1)
           NewQuestionPositive();
        else if (Negative == 2)
           NewQuestionNegative();
        anim.SetFloat("Speed", (float)(0.65 + Difficulty / 20));

    }
    private void NewQuestionPositive()
    {
        
        x = Random.Range(1+ (int)Difficulty, 5 + (int)Difficulty);
        y = Random.Range(1, 5 + (int)Difficulty);
        result = x + y;

        int position = Random.Range(1, 4);
        switch (position)
        {
            case 1:
                gameObject.GetComponent<Text>().text = "? + " + y + " = " + result;
                ButtonPossition(x);
                compare = x;
                break;

            case 2:
                gameObject.GetComponent<Text>().text = x + " + ? = " + result;
                ButtonPossition(y);
                compare = y;
                break;

            case 3:
                gameObject.GetComponent<Text>().text = x + " + " + y + " = ?";
                ButtonPossition(result);
                compare = result;
                break;
        }
        
    }

    private void NewQuestionNegative()
    {
        x = Random.Range(1 + (int)Difficulty, 8 + (int)Difficulty);
        y = x - Random.Range(1, x - 1);
        result = x - y;

        int position = Random.Range(1, 4);
        switch (position)
        {
            case 1:
                gameObject.GetComponent<Text>().text = "? - " + y + " = " + result;
                ButtonPossition(x);
                compare = x;
                break;

            case 2:
                gameObject.GetComponent<Text>().text = x + " - ? = " + result;
                ButtonPossition(y);
                compare = y;
                break;

            case 3:
                gameObject.GetComponent<Text>().text = x + " - " + y + " = ?";
                ButtonPossition(result);
                compare = result;
                break;
        }
    }

    public void ResetButtons()
    {
        resetleft.anim.SetInteger("IsCorrect", 0);
        resetright.anim.SetInteger("IsCorrect", 0);
        if (!IsPressed)
            score.UpdateScore(false);
        else
            IsPressed = false;
    }
    void ButtonPossition(int content)
    {
        int unknown = Random.Range(1, 3);
        if (unknown == 1)
        {
            leftbutton.text = "" + content;
            rightbutton.text = "" + (content + Random.Range(1, 7));
        }
        else if (unknown == 2)
        {
            rightbutton.text = "" + content;
            leftbutton.text = "" + (content + Random.Range(1, 7));
        }
    }
}
