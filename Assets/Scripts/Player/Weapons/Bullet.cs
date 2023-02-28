using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< Updated upstream

    private void Start()
    {
        Destroy(this.gameObject, 7);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
=======
    public class Bullet : MonoBehaviour
    {
        public int damage = 1;
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
