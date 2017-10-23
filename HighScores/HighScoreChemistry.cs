using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreChemistry : MonoBehaviour {
    private int HightScoreChemistry;
    private TheQuestion script2;
    public GameObject QuestionPanel;
    void Awake () {
       // HightScoreChemistry = SaveSystem.system.Quiz_Chem;
        HightScoreChemistry = PlayerPrefs.GetInt("chem");
        script2 = QuestionPanel.GetComponent<TheQuestion>();
        gameObject.GetComponentInChildren<Text>().text = "IQ: " + HightScoreChemistry;
    }
    public void ChemistryScoreChange()
    {
        if (HightScoreChemistry < script2.CountHimiq)
        {
            PlayerPrefs.SetInt("chem", script2.CountHimiq);
            //SaveSystem.system.Quiz_Chem = script2.CountHimiq;
            HightScoreChemistry = script2.CountHimiq;
            gameObject.GetComponentInChildren<Text>().text = "IQ: " + HightScoreChemistry;
        }
    }
}
