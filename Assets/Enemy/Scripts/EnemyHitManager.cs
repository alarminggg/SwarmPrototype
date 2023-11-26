using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 25f;

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        Debug.Log("Enemy Hit: " + hitPoints.ToString());


        if (hitPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }

    void SelfTerminate()
    {
        Destroy(gameObject);
    }
}
