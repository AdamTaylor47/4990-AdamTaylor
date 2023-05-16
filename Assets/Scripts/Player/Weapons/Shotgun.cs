using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ShootScript
{
    public int numberOfShotgunBullets;
    public float maxSpread;
        
    public override void Shoot()
    {
        nextFire = Time.time + fireRate;
        for (int i = 0; i < numberOfShotgunBullets; i++) 
        {
            GameObject activeBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = activeBullet.GetComponent<Rigidbody2D>();
            rb.transform.Rotate(0, 0, Random.Range(maxSpread, -maxSpread));
            var bulletScript = activeBullet.GetComponent<Bullet>();
            bulletScript.damage = gunDamage;
            rb.AddForce(rb.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
    
}
