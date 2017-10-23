using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HighScorePhysics : MonoBehaviour {
    private int HightScorePhysics;
    private TheQuestion script2;
    public GameObject QuestionPanel;
    void Awake()
    {
        //HightScorePhysics = SaveSystem.system.Quiz_Phy; 
        HightScorePhysics = PlayerPrefs.GetInt("Phy");
        script2 = QuestionPanel.GetComponent<TheQuestion>();
        gameObject.GetComponentInChildren<Text>().text = "IQ: " + HightScorePhysics;
    }
    public void PhysicsScoreChange()
    {
        if (HightScorePhysics < script2.CountFizika)
        {
            //SaveSystem.system.Quiz_Phy = script2.CountFizika;
            PlayerPrefs.GetInt("Phy", script2.CountFizika);
            HightScorePhysics = script2.CountFizika;
            gameObject.GetComponentInChildren<Text>().text = "IQ: " + HightScorePhysics;
        }
    }
}
