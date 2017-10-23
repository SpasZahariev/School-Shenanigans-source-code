using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ButtonDialog : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "NPC" || col.tag == "Sign")
        {

        }
    } 
}
