using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.Serialization;
>>>>>>> Stashed changes
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int currentHealth = 0;
    public int maxHealth = 10;
    public Rigidbody2D playerRB;

    public HealthBar healthbar;

    private void Start()
    {
<<<<<<< Updated upstream
        currentHealth = maxHealth;
=======
        public float currentHealth = 0f;
        public float maxHealth = 10f;
        public Image healthBar;
        

        [FormerlySerializedAs("playerRB")] public Rigidbody2D playerRb;

        

        private void Start()
        {
            currentHealth = maxHealth;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet")) 
            {
                TakeDamage();
            }
        }

        public void TakeDamage() 
        {
            currentHealth -= 1;
            healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1f);
            
        }

        


>>>>>>> Stashed changes
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
