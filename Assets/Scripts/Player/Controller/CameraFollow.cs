using UnityEngine;

namespace Player.Controller
{
    public class CameraFollow : MonoBehaviour
    {

        public Transform player;
        public Camera cam;

        private void Awake()
        {
        
        }
        // Update is called once per frame
        private void Update()
        {
            transform.position = new(player.position.x, player.position.y, -10);
        }
    }
}
