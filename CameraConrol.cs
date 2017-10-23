using UnityEngine;
using System.Collections;

public class CameraConrol : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

	void Start () {

        player = GameObject.FindGameObjectWithTag("Player1");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX+0.4f, posY, transform.position.z);
    }
}
