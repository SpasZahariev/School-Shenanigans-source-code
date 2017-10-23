using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] enemies;
    private int enemySelector;


	void Start () {


    }
	

	void Update () {
	
	}

    void OnEnable()
    {
        enemySelector = Random.Range(0, enemies.Length);
        GameObject newEnemy = enemies[enemySelector];
        
        if (newEnemy.CompareTag("Pickup") && Time.time>3f)
        {
            Instantiate(enemies[enemySelector], transform.position,Quaternion.identity);
        }
    }
}
