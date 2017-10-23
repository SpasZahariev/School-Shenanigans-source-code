using UnityEngine;
using System.Collections;

public class PhysicsTopic : MonoBehaviour {
    public static PhysicsTopic Physics;
    public GameObject MainPanel;
    public GameObject Question;
    public GameObject SecondPanel;
    public bool Fizika=false;
    public void OnCklick()
    {
        Fizika = true;
        SecondPanel.SetActive(true);
        MainPanel.SetActive(false);
        Question.GetComponent<TheQuestion>().Fuck();
    }
}
