using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> Platformi;

    

	// Use this for initialization
	void Start () {

        Platformi = new List<GameObject>();

        for(int i=0;i<pooledAmount;i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            Platformi.Add(obj);
        }
	}
	

    public GameObject GetPooledObject()
    {
        for(int i=0;i<Platformi.Count;i++)
        {
            if(!Platformi[i].activeInHierarchy)
            {
                return Platformi[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        Platformi.Add(obj);
        return obj;
    }
}
