using UnityEngine;
using System.Collections;

public class Piano_Retry : MonoBehaviour {


    public Piano_Score score;

    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Piano_Score>();
    }
    public void OnClick()
    {
        score.StartGame();
    }

}
