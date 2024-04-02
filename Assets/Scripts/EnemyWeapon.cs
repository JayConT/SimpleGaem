using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePointA;
    public Transform firePointB;
    public GameObject firedProjectile;
    private float fireTimer = 2.5f;

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0.0f)
        {
            FireWeapon();
            fireTimer = 2f;
        }
    }

    void FireWeapon()
    {
        GameObject bulletA = Instantiate(firedProjectile, firePointA.position, firePointA.rotation);
        GameObject bulletB = Instantiate(firedProjectile, firePointB.position, firePointB.rotation);
        Destroy(bulletA, 2f);
        Destroy(bulletB, 2f);
    }
}
