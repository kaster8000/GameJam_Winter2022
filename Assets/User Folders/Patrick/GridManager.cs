using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager: MonoBehaviour
{
    /*
     * Define (1)obstacles
     * Define the (2)grid and its (3)size in world space.
     * (4)Create the grid
     * Create the nodes in the grid(5)
     * Find locations within the grid – neighbours and locations(6)
     * (7)Display the grid?
    */
    public bool ShowGrid;
    public LayerMask obstacleMask;  // what layer are obstacles?  (1)
    public Vector2 gridWorldSize; //how large is the grid  (3)
    public float nodeRadius;  //how big is each node.  How 
    Node[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Awake()
    {
        nodeDiameter = 2 * nodeRadius;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    /*
     * Create grid is a public fuction, which means that you can call it if your grid is changed during game play.
     * Be careful.  If you create an area that is unreachable your calculations to find a path will search the entire grid looking for a valid path.
    */
    public void CreateGrid()  //(4)
    {
        grid = new Node[gridSizeX, gridSizeY];  // (2)
        Vector3 worldBottomLeft = transform.position - (Vector3.right * gridWorldSize.x / 2) - Vector3.up * gridWorldSize.y / 2;  //where does the grid start?
        
        for(int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                //bool isWalkable = !(Physics2D.CircleCast(worldPoint, nodeRadius, Vector2.zero, obstacleMask));  //CircleCast works in the same manner as OverlappingCircle, but does it all in one line...
                
                bool isWalkable = true;
                if (Physics2D.OverlapCircle(worldPoint, nodeRadius, obstacleMask) != null) isWalkable = false;  //using same concept as we did for the melee combat
                grid[x, y] = new Node(isWalkable, worldPoint, new Vector2(x,y));  //(5)
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)  // returns a node a specific world point
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public List<Node> GetNeighbours(Node node)  //find all neighbouring nodes  (6)
    {
        List<Node> neighbours = new List<Node>();

        for(int x = -1; x<=1; x++)
        {
            for(int y = -1; y<=1; y++)
            {
                if (x == 0 && y == 0) continue;
                int checkX = (int)node.gridLocation.x + x;
                int checkY = (int)node.gridLocation.y + y;

                if(checkX>=0 && checkX<gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }

            }
        }
        return neighbours;
    }

    public List<Node> path;  //visualize path


    private void OnDrawGizmos()  //for visualization of grid in editor  (7)
    {
        if(ShowGrid)
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 0.1f));

            if (grid != null)
            {
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.traversable) ? Color.white : Color.red;
                    if (path != null)  //visualize path
                    {
                        if (path.Contains(n)) Gizmos.color = Color.black;
                        if (n == path[path.Count - 1]) Gizmos.color = Color.blue;
                    }
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
                }
            }
        }

    }
        

}
