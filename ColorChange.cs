using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

    //private FallingPlatform theFallingPlatform;
    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //theFallingPlatform.contact = GetComponentInParent<FallingPlatform>().contact;
        if(GetComponentInParent<FallingPlatform>().contact)
        {
            rend.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        if (GetComponentInParent<FallingPlatform>().contact==false)
        {
            rend.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
