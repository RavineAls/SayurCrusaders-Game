using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject strongEnemyPrefab; // Prefab for the stronger enemy
    public GameObject[] weakEnemyPrefab; // Prefab for the weaker enemy
    public Transform[] spawnPoints; // Array of spawn points for enemies
    public WaveCounter wvCount;
    public AudioSource waveStart;
    public AudioSource enemySpawn;
    public PlayerScript pScript;
    public VictoryScreen VicScreen;


    public int initialDelay = 5; // Initial delay before the first wave starts
    public float timeBetweenWaves = 5f; // Time delay between waves

    private int currentWave = 0;
    private int spawnedEnemies = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialDelay);

        while (currentWave < 5) // Adjust the number of waves as needed
        {
            waveStart.Play();
            pScript.Heal(5);
            yield return new WaitForSeconds(1f);
            currentWave++;
            wvCount.WaveStart(currentWave);
            StartCoroutine(SpawnWave());

            // Wait for all enemies to be defeated
            yield return new WaitUntil(() => spawnedEnemies == 0);

            yield return new WaitForSeconds(timeBetweenWaves);
        }

        // All waves spawned, game over or victory condition
        Debug.Log("All waves spawned!");
        VicScreen.gameClear("Arena Clear");
    }

    private IEnumerator SpawnWave()
    {
        int strongEnemyCount = currentWave;
        int weakEnemyCount = currentWave * 2;

        for (int i = 0; i < strongEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            spawnPoint.position = new Vector3(spawnPoint.position.x, 2.6f, spawnPoint.position.z);

            SpawnPrefab(strongEnemyPrefab, spawnPoint);
            spawnedEnemies++;

            yield return new WaitForSeconds(0.7f/currentWave);
        }

        for (int i = 0; i < weakEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            int randomEnIndex = Random.Range(0, weakEnemyPrefab.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            SpawnPrefab(weakEnemyPrefab[randomEnIndex], spawnPoint);
            spawnedEnemies++;

            yield return new WaitForSeconds(0.7f/currentWave);
        }
    }

    public void SpawnPrefab(GameObject prefab, Transform spawnPoint)
    {
        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

        // Get the references from the instantiated object
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyCounter enCount = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<EnemyCounter>();
        WaveSpawner wvSpwnr = GameObject.FindGameObjectWithTag("Spawner").GetComponent<WaveSpawner>();

        // Assign the references to the instantiated object's script
        EnemyScript enemyScript = spawnedObject.GetComponent<EnemyScript>();
        enemyScript.playerTransform = playerTransform;
        enemyScript.enCount = enCount;
        enemyScript.wvSpwnr = wvSpwnr;
        enemyScript.vScrn = VicScreen;
        enemySpawn.Play();
    }

    public void EnemyDefeated()
    {
        spawnedEnemies--;
    }
}
