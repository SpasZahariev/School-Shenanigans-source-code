using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCMovement : MonoBehaviour
{

    public float speed;
    private Animator anim;
    public Vector2 Direction;
    public int Horizontal;
    public bool NPCCanMove = true;
    private GameObject Textbox;
    private Conversation dialog;

    void Start()
    {
        anim = GetComponent<Animator>();
        dialog = FindObjectOfType<Conversation>();
    }

    void Update()
    {
        if (NPCCanMove)
        {
            transform.Translate(Direction * speed * Time.deltaTime);
            switch (Horizontal = (int)Direction.x)
            {
                case 0:
                    anim.SetFloat("MoveHorizontal", 0);
                    break;
                case 1:
                    anim.SetFloat("MoveHorizontal", 1);
                    break;
                case -1:
                    anim.SetFloat("MoveHorizontal", -1);
                    break;
            }
        }
        else
        {
            anim.SetFloat("MoveHorizontal", 0);
            if (!dialog.show)
            {
                NPCCanMove = true;
            }
        }
          
    }

}
