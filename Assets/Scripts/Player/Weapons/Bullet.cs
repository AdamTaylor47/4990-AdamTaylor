using UnityEngine;

namespace Player.Weapons
{
    public class Bullet : MonoBehaviour
    {

        private void Start()
        {
            Destroy(this.gameObject, 7);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
        }
    }
}
