using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private GridSystem<PathNode> grid;
    public int x, y;
    public int gCost;
    public int hCost;
    public int fCost;
    public PathNode comeFromNode;
    public bool isWalkable;
    public PathNode(GridSystem<PathNode> grid, int x, int y) 
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable= true;
    }

    public void SetIsWalkable(bool isWalkable) 
    {
        this.isWalkable = isWalkable;
        grid.TriggerGridObjectChanged(x,y);
    }
    public void CalculateFCost() 
    {
        fCost = gCost + hCost;
    }
    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
    public override string ToString()
    {
        return x + "," + y;
    }

}
