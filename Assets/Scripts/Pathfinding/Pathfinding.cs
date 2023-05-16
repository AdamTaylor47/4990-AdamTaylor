using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding 
{

    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;


    private GridSystem<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;


    public static Pathfinding instance;
    public static RaycastHit2D ray;
    public LayerMask layerMask;
    public LayerMask layerMask2;
    public Pathfinding(int width, int height) 
    {
        instance = this;
        grid = new GridSystem<PathNode>(width, height,2f,Vector3.zero,(GridSystem<PathNode> g, int x, int y) => new PathNode(g,x,y));
    }

    public GridSystem<PathNode> GetGrid() 
    {
        
        return grid;
    }

    public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition) 
    {
        grid.GetXY(startWorldPosition, out int startX, out int startY);
        grid.GetXY(endWorldPosition, out int endX, out int endY);

        List<PathNode> path = FindPath(startX,startY,endX,endY);
        if (path == null)
        {
            return null;
        }
        else 
        {
            List<Vector3> vectorPath = new List<Vector3>();
            foreach (PathNode pathNode in path) 
            {
                vectorPath.Add(new Vector3(pathNode.GetX(), pathNode.GetY()) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f);
            }
            return vectorPath;
        }
    }

    public List<PathNode> FindPath(int startX, int startY, int endX, int endY) 
    {
        PathNode startNode = grid.GetGridObject(startX,startY);
        PathNode endNode = grid.GetGridObject(endX,endY);
        bool original = endNode.isWalkable;
        endNode.isWalkable = true;
        /*
        if (!endNode.isWalkable) 
        {
            return null;
        }
        */
        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++) 
        {
            for(int y = 0; y < grid.GetHeight(); y++) 
            {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.comeFromNode = null; 
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while(openList.Count > 0) 
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode) 
            {
                endNode.isWalkable = original;
                return CalculatePath(endNode);
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighborNode in GetNeighborList(currentNode)) 
            {
                if (closedList.Contains(neighborNode)) continue;
                
                


                if (!neighborNode.isWalkable) 
                {
                    closedList.Add(neighborNode);
                    continue;
                }

                int tentativeCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
                if (tentativeCost < neighborNode.gCost) 
                {
                    neighborNode.comeFromNode = currentNode;
                    neighborNode.gCost = tentativeCost;
                    neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
                    neighborNode.CalculateFCost();

                    if (!openList.Contains(neighborNode)) 
                    {
                        openList.Add(neighborNode);
                    }
                }
            }
            
        }
        //out of nodes on the openList
        // searched through whole map and found no path
        endNode.isWalkable = original;
        return null;
    }

    public PathNode GetNode(int x, int y) 
    {
        return grid.GetGridObject(x, y);
    }
    public List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while(currentNode.comeFromNode!= null) 
        {
            path.Add(currentNode.comeFromNode);
            currentNode = currentNode.comeFromNode;

        }
        path.Reverse();
        return path;
    }

    private List<PathNode> GetNeighborList(PathNode currentNode) 
    {
        List<PathNode> neighborList = new List<PathNode>();


        if (currentNode.GetX() - 1 >= 0) 
        {
            //left
            neighborList.Add(GetNode(currentNode.GetX() - 1, currentNode.GetY()));
            //left down
            if(currentNode.GetY() - 1 >= 0) 
            {
                neighborList.Add(GetNode(currentNode.GetX()-1,currentNode.GetY()-1));
            }
            //letf up
            if(currentNode.GetY()+1 < grid.GetHeight()) 
            {
                neighborList.Add(GetNode(currentNode.GetX()-1,currentNode.GetY()+1));
            }
        }
        if(currentNode.GetX() + 1 < grid.GetWidth()) 
        {
            //right
            neighborList.Add(GetNode(currentNode.GetX()+1,currentNode.GetY()));
            //right downm
            if (currentNode.GetY() - 1 >= 0) 
            {
                neighborList.Add(GetNode(currentNode.GetX()+1,currentNode.GetY()-1));
            }
            //right up
            if (currentNode.GetY() + 1 < grid.GetHeight()) 
            {
                neighborList.Add(GetNode(currentNode.GetX()+1,currentNode.GetY()+1));
            }
        }
        //down
        if (currentNode.GetY() - 1 >= 0) 
        {
            neighborList.Add(GetNode(currentNode.GetX(),currentNode.GetY()-1));
        }
        //up
        if (currentNode.GetY() + 1 < grid.GetHeight()) 
        {
            neighborList.Add(GetNode(currentNode.GetX(), currentNode.GetY() + 1));
        }
        return neighborList;
    }

    public int CalculateDistanceCost(PathNode a, PathNode b) 
    {
        int xDistance = Mathf.Abs(a.GetX() - b.GetX());
        int yDistance = Mathf.Abs(a.GetY() - b.GetY());
        int remaining = Mathf.Abs(xDistance- yDistance);

        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList) 
    {
        PathNode lowestFCostNode = pathNodeList[0];
        for(int i = 1; i < pathNodeList.Count; i++) 
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost) 
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }

    public void AddTerain(int width, int height, Pathfinding pathfinding) 
    {
        for (int i = 1; i < width; i+=2) 
        {
            for(int k = 1; k < height; k+=2) 
            {
                Vector3 v = new Vector3(i,k,0);
                layerMask = LayerMask.GetMask("Walls");
                layerMask2 = LayerMask.GetMask("ShortWalls");

                RaycastHit2D ray = Physics2D.Raycast(v, Vector3.back,layerMask) ;
                RaycastHit2D ray2 = Physics2D.Raycast(v, Vector3.back, layerMask);
                if (ray.collider != null || ray2.collider != null)
                {
                    //Debug.DrawRay(v, Vector3.back, Color.red, duration: 30);
                    //Debug.Log(pathfinding.GetNode(i, k));
                    pathfinding.GetGrid().GetXY(v, out int x, out int y);
                    pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);

                }
                else {
                   // Debug.DrawRay(v, Vector3.back, Color.blue, duration: 30);
                }
                
            }
        }
    }
}
