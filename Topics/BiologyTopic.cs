using UnityEngine;
using System.Collections;

public class BiologyTopic : MonoBehaviour {
    public static BiologyTopic Biology;
    public GameObject MainPanel;
    public GameObject Question;
    public GameObject SecondPanel;
    public bool Biologiq=false;
    public void OnCklick ()
    {
        Biologiq = true;
        SecondPanel.SetActive(true);
        MainPanel.SetActive(false);
        Question.GetComponent<TheQuestion>().Fuck();
    }
}
