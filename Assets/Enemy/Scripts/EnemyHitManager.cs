using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{
    public int maxhealth = 50;
    public int currentHealth;

    public event Action OnEnemyDeath;
    void Start()
    {
        currentHealth = maxhealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            OnEnemyDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
