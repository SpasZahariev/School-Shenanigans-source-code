using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Play()
    {
        SceneManager.LoadScene("RunForrest");
       // Application.LoadLevel("RunForrest");
    }
}
