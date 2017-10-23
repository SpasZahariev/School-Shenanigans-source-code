using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float falldelay;
    public bool contact = false;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player1"))
        {
            contact = true;
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(falldelay);
        rb2d.isKinematic = false;
        yield return 0;
    }
}
