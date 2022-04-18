using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    /*
     *Track Gcost (1)
     *Track Hcost (2)
     *Calculate Fcost (3)
     *Link to the parent node (4)
     *Is the node traversable? (5)
     *Where is it in the grid? (6)
    */

    public bool traversable;  //is the location traversable (true) (5)
    public Vector3 worldPosition;  //location in world space coords

    public int gCost;  //distance from start  (1)
    public int hCost;  //distacne to target  (2)

    public Vector2 gridLocation;  //location in the grid (6)

    public Node parentNode;  // (4)
    
    public int fCost {
        get { return gCost + hCost; }  // (3)  No need to maintain, can simply calculate.
    }
    
    public Node(bool isTraversable, Vector3 worldPos, Vector2 gridLoc)  //Node Constructor
    {
        traversable = isTraversable;
        worldPosition = worldPos;
        gridLocation = gridLoc;
    }
}
