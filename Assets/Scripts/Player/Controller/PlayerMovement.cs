using UnityEngine;

namespace Player.Controller
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movementSpeed = 5f;

        public Rigidbody2D rb;
        public Camera cam;


        private Vector2 _movement;
        private Vector2 _mouse;

        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            _mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + _movement * movementSpeed * Time.fixedDeltaTime);

            Vector2 direction = _mouse - rb.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
