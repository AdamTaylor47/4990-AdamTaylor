using Enemies.Controller;
using UnityEngine;

namespace Enemies.Weapons
{
    public class EnemyShotgun : EnemyShootScript
    {

        public int numberOfShotgunBullets;
        public float maxSpread;

        public override void EnemyShoot()
        {
            enemyNextFire = Time.time + enemyFireRate;
            for (int i = 0; i < numberOfShotgunBullets; i++) 
            {
                GameObject enemyActiveBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
                Rigidbody2D rb = enemyActiveBullet.GetComponent<Rigidbody2D>();
                rb.transform.Rotate(0, 0, Random.Range(maxSpread, -maxSpread));
                rb.AddForce(rb.transform.up * enemyBulletSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
