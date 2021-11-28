using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private float spawnRange = 15.0f;
    private float spawnMaxHeight = 10.0f;
    private float spawnLowHeight = 1.0f;
    private int enemyCount;
    private int enemyWave = 1;

    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            enemyWave += 2;
            SpawnEnemyWave(enemyWave);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
            if (enemyWave >= 7)
            {
                enemyWave = 0;
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRange, -spawnRange);
        float spawnPosY = Random.Range(spawnMaxHeight, spawnLowHeight);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        Vector2 cannotSpawn = new Vector2(0,0);
        if (randomPos == cannotSpawn)
        {
            Vector2 generateNew = new Vector2(spawnPosX, spawnPosY);
        }
        return randomPos;
    }
}
