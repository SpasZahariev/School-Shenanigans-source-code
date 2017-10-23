using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour {
	private Vector3 maxY;// = new Vector3 (transform.position.x,7,transform.position.z);
	private Vector3 minY;// = new Vector3 (transform.position.x,-5,transform.position.z);
	private float eleSpeed;

	// Use this for initialization
	void Start () {
	
		maxY = new Vector3 (transform.position.x, 7, transform.position.z);
		minY = new Vector3 (transform.position.x, -3, transform.position.z);
		eleSpeed = Random.Range (0.2f, 0.5f);
	}
	void OnEnable()
	{
		maxY = new Vector3 (transform.position.x, 7, transform.position.z);
		minY = new Vector3 (transform.position.x, -3, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (maxY, minY, Mathf.PingPong (Time.time * eleSpeed, 1.0f));
	
}
}