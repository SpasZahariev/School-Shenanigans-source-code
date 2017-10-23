using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public string LevelToChange;
    public GameObject anim;


    IEnumerator OnTriggerEnter2D(Collider2D Player)
    {
        yield return StartCoroutine(anim.GetComponent<FadeAnim>().FadeToBlack());
        if (Player.tag == "Player")
        {
            Player.transform.Translate(new Vector3(0f, -25f, 0f));
            Application.LoadLevel(LevelToChange);
        }
        yield return StartCoroutine(anim.GetComponent<FadeAnim>().FadeToClear());
    }
    public void ChangeSceneFunction()
    {
        Application.LoadLevel(LevelToChange);
    }
}
