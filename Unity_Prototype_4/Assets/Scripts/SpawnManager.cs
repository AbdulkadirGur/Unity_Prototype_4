using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 10.0f;
    public int enemyCount;
    private int waveNumber = 1;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);


    }

    void SpawnEnemyWave(int enemysToSpawn)
    {
        for (int i = 0; i < enemysToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            
        }
    }


    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
            

        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosY);
        return spawnPos;
    }


}
