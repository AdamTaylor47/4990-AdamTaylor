using System.Collections;
using UnityEngine;

namespace Player.Weapons
{
    public class ShootScript : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bullet;

        public float bulletSpeed = 20f;
        public float ammo;
        public float magSize;
        public float reloadTime;

        public float fireRate = 1f;
        public float nextFire = 0f;

        private bool _isReloading = false;


        private void Start()
        {
            ammo = magSize;
        }

        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire && _isReloading == false) 
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
        }

        public virtual void Shoot()
        {
            nextFire = Time.time + fireRate;
            GameObject activeBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = activeBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        
        
        }

        private IEnumerator ReloadMag() 
        {
            Debug.Log("Reloading");
            _isReloading = true;
            yield return new WaitForSeconds(reloadTime);
        
            Debug.Log("Done Reloading");
            _isReloading = false;
        }
    }
}
