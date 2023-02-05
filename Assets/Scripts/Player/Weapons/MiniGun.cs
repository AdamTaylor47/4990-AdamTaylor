using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : ShootScript
{
    public float maxSpread;
    
    public override void Shoot() 
    {
        nextFire = Time.time + fireRate;
        GameObject activeBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = activeBullet.GetComponent<Rigidbody2D>();
        rb.transform.Rotate(0,0,Random.Range(maxSpread,-maxSpread));
        rb.AddForce(rb.transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
    

}
