using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public int currentHealth = 0;
        public int maxHealth = 10;
        [FormerlySerializedAs("playerRB")] public Rigidbody2D playerRb;

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

        public void DamagePlayer(int damage) 
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
        }


    }
}
