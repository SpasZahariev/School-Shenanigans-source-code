using UnityEngine;
using System.Collections;

public class NotePool : MonoBehaviour {

    public GameObject pooledNote;
    public int pooledAmount;

    GameObject[] notes;
	// Use this for initialization
	void Start () {
        for(int i=0;i<pooledAmount;i++)
        {
            notes[i]=(GameObject)Instantiate(pooledNote, transform.position, Quaternion.identity);
            notes[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetPooledNote()
    {
       // int i = 0;
        for(int i=0; i<5;i++)
        {
            if(!notes[i].activeInHierarchy)
            {
                return notes[i];
            }
        }
        /*notes[i+1] = (GameObject)Instantiate(pooledNote, transform.position, transform.rotation);
        notes[i + 1].SetActive(false);
        return notes[i + 1];*/
        return null;
    }
}
