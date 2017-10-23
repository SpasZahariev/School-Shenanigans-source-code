using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler[] theObjectPools;

    private float platformWidth;

    private int platformSelector;
    private float[] platformWidths;

    private float minHight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


	void Start () {

        minHight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        platformWidths = new float[theObjectPools.Length];
        for(int i=0;i<theObjectPools.Length;i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
	
	}

	void Update () {

        

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)//tezi redove ne sa zaduljitelni zashtoto camera sledva player
            { heightChange = maxHeight; }
            else if(heightChange<minHight)
            { heightChange = minHight; }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2)+ distanceBetween , heightChange, transform.position.z);


     

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            //newPlatform.transform.rotation = transform.rotation;
			if(newPlatform.CompareTag("FallingPlatform"))
			{
				newPlatform.GetComponent<Rigidbody2D>().isKinematic= true;
                newPlatform.GetComponent<FallingPlatform>().contact = false;
				//newPlatform.GetComponent<Collider2D>().isTrigger=false;
			}

            newPlatform.SetActive(true);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	
	}
}
