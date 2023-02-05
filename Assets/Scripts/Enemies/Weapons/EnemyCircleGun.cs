using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleGun : EnemyShootScript
{
    public int numberOfBullets;
    public float distanceBetweenBullets;
    private float x = 0;
    

    public override void EnemyShoot()
    {
        distanceBetweenBullets = 360 / numberOfBullets;
        EnemyNextFire = Time.time + EnemyFireRate;
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject EnemyActiveBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
            Rigidbody2D rb = EnemyActiveBullet.GetComponent<Rigidbody2D>();
            rb.transform.Rotate(0, 0, x);
            x += distanceBetweenBullets;
            rb.AddForce(rb.transform.up * enemyBulletSpeed, ForceMode2D.Impulse);
            Destroy(EnemyActiveBullet, 1);
        }
    }
}
