using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] EnemySpawnPoints;
    public float spawnInterval = 2f;
    public int initialSpawnCount = 10;
    public float enemiesIncreaseFactor = 1.5f;

    private int currentSpawnCount;
    private int totalSpawnedEnemies;
    private int deadEnemies;

    void Start()
    {
        StartNewSpawn();
    }

    void StartNewSpawn()
    {
        currentSpawnCount = Mathf.RoundToInt(initialSpawnCount * Mathf.Pow(enemiesIncreaseFactor, totalSpawnedEnemies));
        deadEnemies = 0;

        // Subscribe to the OnEnemyDeath event
        foreach (var spawnPoint in EnemySpawnPoints)
        {
            GameObject enemy = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
            EnemyHitManager enemyHitManager = enemy.GetComponent<EnemyHitManager>();
            enemyHitManager.OnEnemyDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        deadEnemies++;

        if (deadEnemies >= currentSpawnCount)
        {
            StartNewSpawn();
        }
    }
}
