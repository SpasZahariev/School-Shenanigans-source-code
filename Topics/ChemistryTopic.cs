using UnityEngine;
using System.Collections;

public class ChemistryTopic : MonoBehaviour {
    public static ChemistryTopic Chemistry;
    public GameObject MainPanel;
    public GameObject Question;
    public GameObject SecondPanel;
    public bool Himiq=false;
    public void OnCklick()
    {
        Himiq = true;
        SecondPanel.SetActive(true);
        MainPanel.SetActive(false);
        Question.GetComponent<TheQuestion>().Fuck();
    }
}
