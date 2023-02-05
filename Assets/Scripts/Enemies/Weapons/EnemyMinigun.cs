using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinigun : EnemyShootScript
{
    public int minigunBullets;
    public int minigunReloadTime;
    public override void EnemyShoot()
    {
        for (int i = 0; i <= minigunBullets; i++) 
        {
            EnemyNextFire = Time.time + EnemyFireRate;
            GameObject enemyActiveBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
            Rigidbody2D rb = enemyActiveBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(rb.transform.up * enemyBulletSpeed, ForceMode2D.Impulse);
        }
        
    }

    IEnumerator minigunReload()
    {
        
        yield return new WaitForSeconds(minigunReloadTime);
    }
}
