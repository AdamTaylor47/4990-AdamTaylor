using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Testing : MonoBehaviour
{
    private Pathfinding pathfinding;
    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
    }

    
    private void Update()
    {
        
        if(Input.GetMouseButton(0)) 
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition,out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if(path != null) 
            {
                for(int i=0; i<path.Count - 1;i++) 
                {
                   Debug.DrawLine(new Vector3(path[i].GetX(), path[i].GetY()) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].GetX(), path[i + 1].GetY()) * 10f + Vector3.one * 5f, Color.red);
                }
            }
        }
        
    
        if (Input.GetMouseButtonDown(1)) 
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition,out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }
        
    }
    
}
