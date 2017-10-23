using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HighScoreBiology : MonoBehaviour {
    private int HightScoreBiology;
    private TheQuestion script2;
    public GameObject QuestionPanel;
    void Awake()
    {
       // SaveSystem.system.Load();
        //ightScoreBiology = SaveSystem.system.Quiz_Bio;

        HightScoreBiology = PlayerPrefs.GetInt("Bio");

        script2 = QuestionPanel.GetComponent<TheQuestion>();
        gameObject.GetComponentInChildren<Text>().text = "IQ: " + HightScoreBiology;
    }
    public void BiologyScoreChange()
    {
        if (HightScoreBiology < script2.CountBiologiq)
        {
            PlayerPrefs.SetInt("Bio", script2.CountBiologiq);
            //SaveSystem.system.Quiz_Bio = script2.CountBiologiq;
            HightScoreBiology = script2.CountBiologiq;
            gameObject.GetComponentInChildren<Text>().text = "IQ: " + HightScoreBiology;
        }
    }
}
