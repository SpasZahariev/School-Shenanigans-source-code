using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Piano_Button : MonoBehaviour
{

    private int answer;
    private int thisresult;
    public Animator anim;
    private Piano_Question ques;
    private Text thisText;
    private Piano_Score score;

    void Awake()
    {
        ques = FindObjectOfType<Piano_Question>();
        thisText = gameObject.GetComponentInChildren<Text>();
        anim = gameObject.GetComponent<Animator>();
        score = GameObject.Find("Score").GetComponent<Piano_Score>();
    }



    public void OnClick()
    {
        if (!ques.IsPressed)
        {
            answer = ques.compare;
            thisresult = StringToInt(thisText.text);
            if (answer == thisresult)
            {
                anim.SetInteger("IsCorrect", 1);
                score.UpdateScore(true);
            }
            else
            {
                anim.SetInteger("IsCorrect", -1);
                score.UpdateScore(false);
            }
            ques.IsPressed = true;
        }
    }

    public int StringToInt(string s)
    {
        int r = 0;
        for (var i = 0; i < s.Length; i++)
        {
            char letter = s[i];
            r = 10 * r;
            r = r + (int)char.GetNumericValue(letter);
        }
        return r;
    }
}
