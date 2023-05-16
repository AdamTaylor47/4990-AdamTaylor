using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    Vector2 direction;

    public float bulletSpeed = 20f;
    public float ammo;
    public float magSize;
    public float reloadTime;

    public float fireRate = 1f;
    public float nextFire = 0f;
    public int gunDamage = 0;

    private bool isReloading = false;
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && isReloading == false) 
        {
            if (ammo > 0)
            {
                Shoot();
                ammo -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            StartCoroutine(ReloadMag());
            ammo = magSize;
        }
        if (ammo <= 0) 
        {
            StartCoroutine(ReloadMag());
            ammo = magSize;
        }

        
    }

    public virtual void Shoot()
    {
        nextFire = Time.time + fireRate;
        GameObject activeBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = activeBullet.GetComponent<Rigidbody2D>();
        var bulletScript = activeBullet.GetComponent<Bullet>();
        bulletScript.damage = gunDamage;
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    IEnumerator ReloadMag() 
    {
        Debug.Log("Reloading");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        
        Debug.Log("Done Reloading");
        isReloading = false;
    }
}
