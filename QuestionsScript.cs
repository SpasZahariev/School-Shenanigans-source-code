using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class QuestionsScript : MonoBehaviour {
    //public static QuestionsScript questionscript;
    private static List<ChemistryQuestions> unanswaredChemistryQuestions;
    private static List<PhysicsQuestions> unanswaredPhysicsQuestions;
    private static List<BiologyQuestions> unanswaredBiologyQuestions;
    public ChemistryQuestions[] VyprosiHimiq;
    public PhysicsQuestions[] VyprosiFizika;
    public BiologyQuestions[] VyprosiBiologiq;
    public ChemistryQuestions currentChemistryQuestion;
    public PhysicsQuestions currentPhysicsQuestion;
    public BiologyQuestions currentBiologyQuestion;
    private int randomIndex;
    void Start()
    {
        if(unanswaredChemistryQuestions==null|| unanswaredChemistryQuestions.Count==0)
        {
            unanswaredChemistryQuestions = VyprosiHimiq.ToList<ChemistryQuestions>();
        }
        if (unanswaredPhysicsQuestions == null || unanswaredPhysicsQuestions.Count == 0)
        {
            unanswaredPhysicsQuestions = VyprosiFizika.ToList<PhysicsQuestions>();
        }
        if (unanswaredBiologyQuestions == null || unanswaredBiologyQuestions.Count == 0)
        {
            unanswaredBiologyQuestions = VyprosiBiologiq.ToList<BiologyQuestions>();
        }
    }

    public void getRandomChemistryQuestion()
    {
        randomIndex = Random.Range(0, unanswaredChemistryQuestions.Count);
        currentChemistryQuestion = unanswaredChemistryQuestions[randomIndex];
        unanswaredChemistryQuestions.RemoveAt(randomIndex);
    }
    public void getRandomPhysicsQuestion()
    {
        randomIndex = Random.Range(0, unanswaredPhysicsQuestions.Count);
        currentPhysicsQuestion = unanswaredPhysicsQuestions[randomIndex];
        unanswaredPhysicsQuestions.RemoveAt(randomIndex);
    }
    public void getRandomBiologyQuestion()
    {
        randomIndex = Random.Range(0, unanswaredBiologyQuestions.Count);
        currentBiologyQuestion = unanswaredBiologyQuestions[randomIndex];
        unanswaredBiologyQuestions.RemoveAt(randomIndex);
    }
    public void SceneChange()
    {
        if (unanswaredChemistryQuestions == null || unanswaredChemistryQuestions.Count == 0)
        {
            unanswaredChemistryQuestions = VyprosiHimiq.ToList<ChemistryQuestions>();
        }
        if (unanswaredPhysicsQuestions == null || unanswaredPhysicsQuestions.Count == 0)
        {
            unanswaredPhysicsQuestions = VyprosiFizika.ToList<PhysicsQuestions>();
        }
        if (unanswaredBiologyQuestions == null || unanswaredBiologyQuestions.Count == 0)
        {
            unanswaredBiologyQuestions = VyprosiBiologiq.ToList<BiologyQuestions>();
        }
    }
}
