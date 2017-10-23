using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonScript : MonoBehaviour {
    public GameObject Right;
    public Text True;
    public GameObject Wrong;
    public GameObject TrueButton;
    public GameObject FalseButton;
    public GameObject TransitionPanel;
    private QuestionsScript script1;
    private TheQuestion script2;
    public GameObject QuestionPanel;
    void Start()
    {
        script2 = QuestionPanel.GetComponent<TheQuestion>();
        script1 = GameObject.Find("Questions").GetComponent<QuestionsScript>();
    }
    public void RightorWrong()
    {
        if (script2.br == 1)
        {
            if (True.text == script1.currentChemistryQuestion.Vqrnost)
            {
                Right.SetActive(true);
                TransitionPanel.SetActive(true);
                script2.CountHimiq = script2.CountHimiq + 1;
            }
            else
            {
                Wrong.SetActive(true);
                TransitionPanel.SetActive(true);
            }
            ActiveDeactive(false);
        }
        if (script2.br == 2)
        {
            if (script1.currentPhysicsQuestion.Vqrnost == True.text)
            {
                Right.SetActive(true);
                TransitionPanel.SetActive(true);
                script2.CountFizika = script2.CountFizika + 1;
            }
            else
            {
                Wrong.SetActive(true);
                TransitionPanel.SetActive(true);
            }
            ActiveDeactive(false);
        }
        if (script2.br == 3)
        {
            if (script1.currentBiologyQuestion.Vqrnost == True.text)
            {
                Right.SetActive(true);
                TransitionPanel.SetActive(true);
                script2.CountBiologiq = script2.CountBiologiq + 1;
            }
            else
            {
                Wrong.SetActive(true);
                TransitionPanel.SetActive(true);
            }
            ActiveDeactive(false);
        }
    }

    public void ActiveDeactive(bool trigger)
    {
        TrueButton.SetActive(trigger);
        FalseButton.SetActive(trigger);
    }
}
