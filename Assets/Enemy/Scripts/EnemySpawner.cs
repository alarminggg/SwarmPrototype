using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] EnemySpawnPoints;
    public int numberOfEnemiesToSpawn = 10;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // Randomly select a spawn point
            int randomSpawnIndex = Random.Range(0, EnemySpawnPoints.Length);
            Transform spawnPoint = EnemySpawnPoints[randomSpawnIndex];

            // Instantiate the enemy at the chosen spawn point
            Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
