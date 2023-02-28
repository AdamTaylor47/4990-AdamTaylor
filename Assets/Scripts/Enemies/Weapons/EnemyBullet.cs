using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void Start()
    {
<<<<<<< Updated upstream
        Destroy(this.gameObject, 7);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
=======
        
        private void Start()
        {
            Destroy(this.gameObject, 7);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(this.gameObject);
        }

>>>>>>> Stashed changes
    }
}
