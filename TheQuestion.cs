using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TheQuestion : MonoBehaviour {
    private Text text;
    public GameObject MainPanel;
    public GameObject SecondPanel;
    public GameObject ObjectScoreChemistry;
    public GameObject ObjectScoreBiology;
    public GameObject ObjectScorePhysics;
    private HighScoreChemistry scriptScoreChemistry;
    private HighScoreBiology scriptScoreBiology;
    private HighScorePhysics scriptScorePhysics;
    public int br = 0;
    public int br2=0;
    public int CountHimiq=0;
    public int CountFizika=0;
    public int CountBiologiq=0;
    public GameObject Himiqq;
    public GameObject Fizikaa;
    public GameObject Biologiqq;
    private QuestionsScript script;
    private PictureTransition script1;
    private bool himiq;
    private bool fizika;
    private bool biologiq;
    void Start ()
    {
        scriptScorePhysics= ObjectScorePhysics.GetComponent<HighScorePhysics>();
        scriptScoreBiology = ObjectScoreBiology.GetComponent<HighScoreBiology>();
        scriptScoreChemistry = ObjectScoreChemistry.GetComponent<HighScoreChemistry>();
    }
    public void Fuck()
    {
        script1 = SecondPanel.GetComponentInChildren<PictureTransition>();
        script = GameObject.Find("Questions").GetComponent<QuestionsScript>();
        himiq = Himiqq.GetComponent<ChemistryTopic>().Himiq;
        fizika = Fizikaa.GetComponent<PhysicsTopic>().Fizika;
        biologiq = Biologiqq.GetComponent<BiologyTopic>().Biologiq;
        text = gameObject.GetComponentInChildren<Text>();
        Nastroika();
        script1.SmqnaSnimka();

    }
    public void Nastroika()
    {
        if (himiq == true)
        {
            if (br2 == script.VyprosiHimiq.Length)
            {
                
                Restart();
                Fuck();
            }
            else
            {
                script.getRandomChemistryQuestion();
                text.text = script.currentChemistryQuestion.VyprosHimiq;
                br = 1;
                br2 = br2 + 1;
            }
            
            
        }
            if (fizika == true)
            {
            if (br2 == script.VyprosiFizika.Length)
            {
                
               Restart();
                Fuck();
            }
            else
                {
                    script.getRandomPhysicsQuestion();
                    text.text = script.currentPhysicsQuestion.VyprosFizika;
                br = 2;
                br2 = br2 + 1;
                }
            
        }
        if (biologiq == true)
        {
            if (br2 == script.VyprosiBiologiq.Length)
            {
                
                Restart();
                Fuck();
            }
            else
                {
                    script.getRandomBiologyQuestion();
                    text.text = script.currentBiologyQuestion.VyprosBiologiq;
                br = 3;
                br2 = br2 + 1;
                }
                
        }
        
    }
    void Restart()
    {
        MainPanel.SetActive(true);
        SecondPanel.SetActive(false);
        br = 0;
        br2 = 0;
        Himiqq.GetComponent<ChemistryTopic>().Himiq = false;
        Biologiqq.GetComponent<BiologyTopic>().Biologiq = false;
        Fizikaa.GetComponent<PhysicsTopic>().Fizika = false;
        script.SceneChange();
        scriptScoreChemistry.ChemistryScoreChange();
        scriptScoreBiology.BiologyScoreChange();
        scriptScorePhysics.PhysicsScoreChange();
       // SaveSystem.system.Save();
        CountHimiq = 0;
        CountFizika = 0;
        CountBiologiq = 0;
}
}
