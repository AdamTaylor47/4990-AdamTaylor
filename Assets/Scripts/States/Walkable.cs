using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Walkable : MonoBehaviour
{

    private const float forcePower = 10f;

    public new Rigidbody2D rb;

    public float speed = 2f;
    public float force = 2f;

    private Vector2 direction;
    public void MoveTo(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Stop()
    {
        MoveTo(Vector2.zero);
    }

    private void FixedUpdate()
    {
        var desiredVelocity = direction * speed;
        var deltaVelocity = desiredVelocity - rb.velocity;
        Vector3 moveForce = deltaVelocity * (force * forcePower * Time.fixedDeltaTime);
        rb.AddForce(moveForce);
        
    }
}