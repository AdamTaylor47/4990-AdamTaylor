using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int currentHealth = 0;
    public int maxHealth = 10;
    public Rigidbody2D playerRB;

    public HealthBar healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")) 
        {
            currentHealth -= 1;
        }
    }

    public void damagePlayer(int damage) 
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }


}
