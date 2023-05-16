using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float desiredDistance = 2f;
    


    public GameObject player;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float distance;
    public float agroRange;

    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    public Pathfinding pathFinding;
    public Tilemap tilemap;


    public void Start()
    {
        
        pathFinding = new Pathfinding(25, 25);
        pathFinding.AddTerain(100, 100, pathFinding);

        player = GameObject.FindGameObjectWithTag("Player");

    }
    public void FixedUpdate()
    {
        RotateTowardsTarget();
        agroRange = Vector3.Distance(player.transform.position, transform.position);
        pathFinding.GetGrid().GetXY(player.transform.position, out int x, out int y);
        pathFinding.GetGrid().GetXY(transform.position, out int j, out int k);
        List<PathNode> path = pathFinding.FindPath(j, k, x, y);
        if (path != null && agroRange < 25)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                
                Movement();
                Debug.DrawLine(new Vector3(path[i].GetX(), path[i].GetY()) * 2f + Vector3.one, new Vector3(path[i + 1].GetX(), path[i + 1].GetY()) * 2f + Vector3.one, Color.red);
            }
        }
        SetTargetPosition(player.transform.position);

    }
    public Vector3 GetPosition() 
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition) 
    {
        currentPathIndex = 0;
        //pathVectorList = Pathfinding.instance.FindPath(GetPosition(), targetPosition);

        List<Vector3> tempList = Pathfinding.instance.FindPath(GetPosition(), targetPosition);

        if (tempList == null)
        {
            return;
        }

        pathVectorList = tempList;

        if (pathVectorList != null && pathVectorList.Count>1) 
        {
            pathVectorList.RemoveAt(0);
        }
    }
    private void Movement() 
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                rb.position = transform.position + (moveDir * movementSpeed * Time.deltaTime);
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    rb.MovePosition((Vector2)transform.position * 0 * Time.deltaTime);
                }
            }
        }
    }
    private void RotateTowardsTarget()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }

}
