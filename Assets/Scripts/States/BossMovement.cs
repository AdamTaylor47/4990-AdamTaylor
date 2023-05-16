using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject target;
    public Walkable walkable;
    public Rigidbody2D rb;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
        var directionTowardsTarget = (target.transform.position - this.transform.position).normalized;
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        walkable.MoveTo(directionTowardsTarget);
    }
}
