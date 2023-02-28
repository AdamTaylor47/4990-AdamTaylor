using Player.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentHealth = 0;
    public float maxHealth = 5;

    //public Image healthBar;
    void Start()
    { 
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet")) 
        {
            var dmg = collision.gameObject.GetComponent<Bullet>();
            currentHealth -= dmg.damage;
           // healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1f);
        }
    }

    private void Update()
    {

        if (currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

}
