using System.Collections;
using Enemies.Controller;
using UnityEngine;

namespace Enemies.Weapons
{
    public class EnemyMinigun : EnemyShootScript
    {
        public int minigunBullets;
        public int minigunReloadTime;
        public override void EnemyShoot()
        {
            for (int i = 0; i <= minigunBullets; i++) 
            {
                enemyNextFire = Time.time + enemyFireRate;
                GameObject enemyActiveBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
                Rigidbody2D rb = enemyActiveBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(rb.transform.up * enemyBulletSpeed, ForceMode2D.Impulse);
            }
        
        }

        private IEnumerator MinigunReload()
        {
        
            yield return new WaitForSeconds(minigunReloadTime);
        }
    }
}
