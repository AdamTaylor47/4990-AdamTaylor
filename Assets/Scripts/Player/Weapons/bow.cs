using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : ShootScript
{
    public int numberOfBowBullets;
    public override void Shoot() 
    {
        int shotAngle = -30;
        nextFire = Time.time + fireRate;
        for (int i = 0; i < numberOfBowBullets; i++) 
        {
            //loop to shoot 3 bullets at once
            GameObject activeBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = activeBullet.GetComponent<Rigidbody2D>();
            rb.transform.Rotate(0, 0, shotAngle);
            rb.AddForce(rb.transform.up * bulletSpeed, ForceMode2D.Impulse);
            shotAngle += 30;
        }
    }
}
