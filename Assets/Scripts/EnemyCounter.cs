using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TMP_Text enemyCountText;

    private void Start()
    {
        UpdateEnemyCount();
    }

    private void UpdateEnemyCount()
    {
        int enemyCount = CountEnemies();

        enemyCountText.text = "Enemy: " + enemyCount.ToString();
    }

    private int CountEnemies()
    {
        int count = 0;

        GameObject[] enemyHardObjects = GameObject.FindGameObjectsWithTag("Enemy_Hard");
        count += enemyHardObjects.Length;

        GameObject[] enemySoftObjects = GameObject.FindGameObjectsWithTag("Enemy_Soft");
        count += enemySoftObjects.Length;

        return count;
    }

    public void EnemySpawnedOrDestroyed()
    {
        UpdateEnemyCount();
    }
}
