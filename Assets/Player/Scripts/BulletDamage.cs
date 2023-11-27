using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            EnemyHitManager enemyHitManager = other.gameObject.GetComponent<EnemyHitManager>();
            if (enemyHitManager != null)
            {
                enemyHitManager.TakeDamage(rawDamage);
            }
        }
    }
}
