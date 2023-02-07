using UnityEngine;

namespace Enemies.Controller
{
    public class EnemyMovement : MonoBehaviour
    {
        public float movementSpeed = 2f;
        public float desiredDistance = 2f;
    


        public Transform player;
        public Rigidbody2D rb;
        private Vector2 _movement;
        private float _distance;


        private void Start()
        {
        
        }

        private void Update()
        {
            //get player direction
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            _movement = direction;
            //player distance
            _distance = Vector2.Distance(player.position, transform.position);
        
        }
        private void FixedUpdate()
        {
            if (_distance > desiredDistance) 
            {
                MoveEnemy(_movement);
            }
            if (_distance < desiredDistance) 
            {
                StopEnemy(_movement);
            }
        
        }

        private void MoveEnemy(Vector2 direction) 
        {
            rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
        }

        private void StopEnemy(Vector2 direction) 
        {
            rb.MovePosition((Vector2)transform.position + (direction * 0 * Time.deltaTime));
        }

    }
}
