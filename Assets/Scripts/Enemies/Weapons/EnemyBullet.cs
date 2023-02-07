using UnityEngine;

namespace Enemies.Weapons
{
    public class EnemyBullet : MonoBehaviour
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
