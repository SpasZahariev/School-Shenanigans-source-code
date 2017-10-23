using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ActivateDialog : MonoBehaviour
{

    private Conversation dialog;
    public TextAsset Text;
    public bool DestroyWhenDone;
    public bool TriggerByCollision;
    public bool TriggerByButton;
    public float TypeSpeed;
    public GameObject button;
    private Conversation conv;

    // celta na tozi script e da vkluchva scriptut-conversation

    void Start()
    {
        dialog = FindObjectOfType<Conversation>();
        conv = GameObject.Find("TextFunction").GetComponent<Conversation>();
    }
    void OnTriggerStay2D(Collider2D player)
    {
            
            if (TriggerByCollision)
                Activate(Text, TypeSpeed);

        if (gameObject.tag == "NPC")
        {
            button.SetActive(true);
            button.GetComponentInChildren<Text>().text = "Talk";
        }

        if (gameObject.tag == "Sign")
        {
            button.SetActive(true);
            button.GetComponentInChildren<Text>().text = "Read";
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Activate(Text, TypeSpeed);
        }


    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            button.SetActive(false);
        }
    }
    public void Activate(TextAsset text, float TypeSpeed)
    {
        Conversation dialog = GameObject.Find("TextFunction").GetComponent<Conversation>();
        dialog.ReActivate(text);
        dialog.typeSpeed = TypeSpeed;
        if (DestroyWhenDone)
            Destroy(this);
    }

}