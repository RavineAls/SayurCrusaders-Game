using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject enCarrot; // Reference to your prefab1
    public GameObject enOrange; // Reference to your prefab2
    public GameObject enTomato; // Reference to your prefab3

    public void SpawnPrefab(GameObject prefab)
    {
        GameObject spawnedObject = Instantiate(prefab);

        // Get the references from the instantiated object
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyCounter enCount = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<EnemyCounter>();
        WaveSpawner wvSpwnr = GameObject.FindGameObjectWithTag("Spawner").GetComponent<WaveSpawner>();

        // Assign the references to the instantiated object's script
        EnemyScript enemyScript = spawnedObject.GetComponent<EnemyScript>();
        enemyScript.playerTransform = playerTransform;
        enemyScript.enCount = enCount;
        enemyScript.wvSpwnr = wvSpwnr;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnPrefab(enCarrot);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnPrefab(enOrange);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnPrefab(enTomato);
        }
    }
}
