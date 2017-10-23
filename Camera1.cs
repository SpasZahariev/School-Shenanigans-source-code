using UnityEngine;
using System.Collections;

public class Camera1 : MonoBehaviour {

    private GameObject player;
    public float lerpSpeed;
    private Vector3 target;
    public static Camera mainCamera;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        target = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, lerpSpeed * Time.deltaTime);
    }
}
