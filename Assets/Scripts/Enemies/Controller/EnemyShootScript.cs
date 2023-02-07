using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies.Controller
{
    public class EnemyShootScript : MonoBehaviour
    {

        [FormerlySerializedAs("EnemyFireRate")] public float enemyFireRate = 1f;
        [FormerlySerializedAs("EnemyNextFire")] public float enemyNextFire = 0f;

        public Transform enemyFirePoint;
        public GameObject enemyBullet;

        public float enemyBulletSpeed = 10f;


        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time > enemyNextFire)
            {
                EnemyShoot();
                EnemyFireDelay();
            }
        }

        public virtual void EnemyShoot()
        {
            enemyNextFire = Time.time + enemyFireRate;
            GameObject activeEnemyBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
            Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(enemyFirePoint.up * enemyBulletSpeed, ForceMode2D.Impulse);

        }

        private IEnumerator EnemyFireDelay() 
        {
            yield return new WaitForSeconds(enemyFireRate);
        }
    }
}