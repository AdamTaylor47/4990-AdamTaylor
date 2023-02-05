using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : EnemyShootScript
{

    public int numberOfShotgunBullets;
    public float maxSpread;

    public override void EnemyShoot()
    {
        EnemyNextFire = Time.time + EnemyFireRate;
        for (int i = 0; i < numberOfShotgunBullets; i++) 
        {
            GameObject EnemyActiveBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
            Rigidbody2D rb = EnemyActiveBullet.GetComponent<Rigidbody2D>();
            rb.transform.Rotate(0, 0, Random.Range(maxSpread, -maxSpread));
            rb.AddForce(rb.transform.up * enemyBulletSpeed, ForceMode2D.Impulse);
        }
    }
}
