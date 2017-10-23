using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            Application.Quit();
        }
    }
}
