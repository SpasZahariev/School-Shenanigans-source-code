using UnityEngine;
using System.Collections;

public class PlayParticle : MonoBehaviour {

    private ParticleSystem brix;

	// Use this for initialization
	void Start () {
        brix = GetComponent<ParticleSystem>();
        brix.Stop();
        brix.enableEmission = false;

    }
    void OnEnable()
    {
        
        brix = GetComponent<ParticleSystem>();
        brix.Stop();
        brix.enableEmission = false;
    }
    // Update is called once per frame
    void Update () {
	    if(GetComponentInParent<FallingPlatform>().contact)
        {
            brix.Play();
            brix.enableEmission = true;


        }
        else if(!GetComponentInParent<FallingPlatform>().contact)
        {
            brix.Stop();
            brix.enableEmission = false;
        }
	}

    
}
