using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

    public Vector2 NewDestination;
    public float newspeed;
    public int Wait;
    public bool ActivateDialog;
    public TextAsset NewDialog;
    public float TypeSpeed;

    void OnTriggerEnter2D(Collider2D NPC)
    {
        if (NPC.tag == "NPC")
        {
            NPCMovement Movement = NPC.gameObject.GetComponent<NPCMovement>();
            Movement.Direction = Vector2.zero;
            if (ActivateDialog)
            {
                NPC.gameObject.GetComponent<ActivateDialog>().Activate(NewDialog, TypeSpeed);
                Movement.NPCCanMove = false;
            }
            StartCoroutine(DestinationChange(Movement));
        }
    }

    IEnumerator DestinationChange(NPCMovement NPC)
    {
        while(!NPC.NPCCanMove)
            yield return new WaitForSeconds(Wait);
        yield return new WaitForSeconds(Wait);
        NPC.speed = newspeed;
        NPC.Direction = NewDestination;
    }
}
