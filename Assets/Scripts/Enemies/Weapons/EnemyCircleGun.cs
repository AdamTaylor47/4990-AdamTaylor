using Enemies.Controller;
using UnityEngine;

namespace Enemies.Weapons
{
    public class EnemyCircleGun : EnemyShootScript
    {
        public int numberOfBullets;
        public float distanceBetweenBullets;
        private float _x = 0;
    

        public override void EnemyShoot()
        {
            distanceBetweenBullets = 360 / numberOfBullets;
            enemyNextFire = Time.time + enemyFireRate;
            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject enemyActiveBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
                Rigidbody2D rb = enemyActiveBullet.GetComponent<Rigidbody2D>();
                rb.transform.Rotate(0, 0, _x);
                _x += distanceBetweenBullets;
                rb.AddForce(rb.transform.up * enemyBulletSpeed, ForceMode2D.Impulse);
                Destroy(enemyActiveBullet, 1);
            }
        }
    }
}
