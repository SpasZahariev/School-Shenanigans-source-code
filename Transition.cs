using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour
{
    private TheQuestion script3;
    public GameObject Right;
    public GameObject TransitionPanel;
    public GameObject Wrong;
    public ButtonScript L;
    void Awake()
    {
        script3 = GameObject.Find("QuestionPanel").GetComponent<TheQuestion>();
    }
    public void ClickMotherFucker()
    {
        script3.Nastroika();
        Right.SetActive(false);
        Wrong.SetActive(false);
        TransitionPanel.SetActive(false);
        L.ActiveDeactive(true);
    }
}
