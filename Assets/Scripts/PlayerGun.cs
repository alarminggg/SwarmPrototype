using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform firingPoint;
    [SerializeField] float firingSpeed;

    public static PlayerGun Instance;
    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if(lastTimeShot + firingSpeed <= Time.time)
        {
            GunProjectile _projectile = ProjectilePool.Instance.Instantiate(firingPoint.position, firingPoint.rotation);
            _projectile.Move();
            lastTimeShot = Time.time;

        }
    }
}
