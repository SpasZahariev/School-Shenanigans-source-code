using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    public GameObject destructPoint;

    void Start()
    {
        destructPoint = GameObject.Find("DestroyAfterThis");
    }
    
    void Update()
    {
        if(transform.position.x<destructPoint.transform.position.x)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
