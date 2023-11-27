using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform targetObject;
    public NavMeshAgent enemy;


    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(targetObject.position);
    }
}
