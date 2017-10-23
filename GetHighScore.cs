using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour {

    public Text theScore;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            theScore.text = "HIGHSCORE: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        }
        else
        {
            theScore.text = "Play to see HighScore";
        }
	
	}
}
