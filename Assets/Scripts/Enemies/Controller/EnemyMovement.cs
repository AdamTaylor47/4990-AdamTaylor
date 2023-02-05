using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float desiredDistance = 2f;
    


    public Transform player;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float distance;


    private void Start()
    {
        
    }

    void Update()
    {
        //get player direction
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //player distance
        distance = Vector2.Distance(player.position, transform.position);
        
    }
    private void FixedUpdate()
    {
        if (distance > desiredDistance) 
        {
            moveEnemy(movement);
        }
        if (distance < desiredDistance) 
        {
            stopEnemy(movement);
        }
        
    }

    void moveEnemy(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }

    void stopEnemy(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * 0 * Time.deltaTime));
    }

}
