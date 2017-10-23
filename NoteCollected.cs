using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteCollected : MonoBehaviour {

    public float bonusTime;
    private ScoreManager theScoreManager;
    public ParticleSystem part;
    
	void Start()
    {
        Destroy(gameObject, 6f);
        theScoreManager = FindObjectOfType<ScoreManager>();
    }
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player1"))
        {
            theScoreManager.countdown += bonusTime;
            part.Play();
            part.enableEmission = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 5f);
        }
    }
    
}
