using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 100f;
    float hitPoints;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    public void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        

        Debug.Log("OUCH: " + hitPoints.ToString());

        if (hitPoints <= 0)
        {
            OnDeath();
        }
    }

    float NormalisedHitPoint()
    {
        return hitPoints / maxHitPoints;
    }

    void OnDeath()
    {
        Debug.Log("GAME OVER - YOU DIED");
        GameManager.Instance.GameOver();
    }
}
