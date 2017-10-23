using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public Text highScoreText;
    public Text timeText;

    public float scoreCount;
    public float highScoreCount;
    public float countdown;

    //public float pointsPerSecond;
    public bool scoreIncreasing;

    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        thePlayer = GameObject.FindGameObjectWithTag("Player1");
	
	}
	
	// Update is called once per frame
	void Update () {
        if(thePlayer.transform.position.x/10>scoreCount)
        scoreCount = thePlayer.transform.position.x/10;

            if(scoreCount>highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "HighScore: " + Mathf.Round(highScoreCount);

        countdown = countdown - Time.deltaTime;
        if(countdown>0)
        {
            timeText.text = "Time: " + Mathf.Round(countdown);
        }
        else if(countdown<=0)
        {
            SceneManager.LoadScene("Dead");
        }
	}
}
