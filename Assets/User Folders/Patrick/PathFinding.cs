using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    //endObj = GameObject.Find("Player").transform;
    //  grid = GameObject.Find("GridGuy").GetComponent<GridManager>();





    Transform startObj;  //the object
    [Header("Normal Shit ")]
    public Transform endObj;  //the target
    public bool UsePlayerDefault = true;
    public float moveSpeed = 10;

    public GridManager grid;




    public bool CanAttack;
    public bool UseIsMoving;
    bool isMoving;


    Rigidbody2D myRB;

    List<Node> path;
    List<Node> openSet;
    List<Node> closedSet;

    int travelPoint = 1;

    bool triggered = true;
    bool MoveAfterSpwan;
    
    

    private void Awake()
    {
        if (endObj != null) gameObject.SetActive(true);
        
    }

    private void OnEnable()
    {
        triggered = true;
        MoveAfterSpwan = false;
        Invoke("SpwanMoveDelay", 0.3f);
    }
    void SpwanMoveDelay()
    {
        MoveAfterSpwan = true;
    }

    private void Start()
    {



        startObj = transform;
        if(UsePlayerDefault)
            endObj = GameObject.Find("Player").transform;
        
        grid = GameObject.Find("AIGrid").GetComponent<GridManager>();
        path = new List<Node>();
        openSet = new List<Node>();
        closedSet = new List<Node>();
        myRB = GetComponent<Rigidbody2D>();

        //wait then set a bool to true 
        if (endObj != null)
            FindPath(startObj.position, endObj.position);

    }


    private void FixedUpdate()
    {
        //the code below is for in class demonstration of pathfinding.  Remove when ready to have object move.
     

        
        //The code below is used to move the start object along the path to the end object.
        if (endObj != null && grid != null && triggered && MoveAfterSpwan)
        {
            
            if (startObj.position != endObj.position)
                FindPath(startObj.position, endObj.position);
            //else
            if (path.Count > 1 && travelPoint <= path.Count) // index out of range? 
            {

                //move towards target
                if (grid.NodeFromWorldPoint(transform.position) == path[travelPoint])
                {
                    travelPoint++;
                }
                //myRB.AddForce(moveSpeed * ((path[travelPoint].worldPosition) - transform.position));
                myRB.velocity = new Vector2(moveSpeed * ((path[travelPoint].worldPosition.x) - transform.position.x), moveSpeed * ((path[travelPoint].worldPosition.y) - transform.position.y));
                isMoving = true;
            }

        }
        
        
    }

    public void SetTarget(Transform theTarget)
    {
        endObj = theTarget;
    }

    public void SetGrid(GridManager theGrid)
    {
        grid = theGrid;
    }


    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        if (!targetNode.traversable) return;

        path.Clear();
        travelPoint = 1;

        openSet.Clear();
        closedSet.Clear();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    GetPath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.traversable || closedSet.Contains(neighbour)) continue;
                    int moveCostToNext = currentNode.gCost + GetHCost(currentNode, neighbour);
                    if (moveCostToNext < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = moveCostToNext;
                        neighbour.hCost = GetHCost(neighbour, targetNode);
                        neighbour.parentNode = currentNode;

                        if (!openSet.Contains(neighbour)) openSet.Add(neighbour);
                    }
                }
            }
        }
    }

    void GetPath(Node startNode, Node endNode)
    {
        path.Clear();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }

        path.Reverse();

        //remove below...visual demonstration in editor only.
        grid.path = path;
    }

    int GetHCost(Node nodeA, Node nodeB)
    {
        //find minimum diagonal distance to be on same level as target, then move horizontally or vertically to target
        int distX = Mathf.Abs((int)nodeA.gridLocation.x - (int)nodeB.gridLocation.x);
        int distY = Mathf.Abs((int)nodeA.gridLocation.y - (int)nodeB.gridLocation.y);

        if (distX > distY) return 14 * distY + 10 * (distX - distY);
        else return 14 * distX + 10 * (distY - distX);
    }

    public void SetTriggered()
    {
        //triggered = isTriggered;

        if (triggered)
        {
            triggered = false;
        }
        else
        {
            triggered = true;
        }
        Debug.Log(triggered + " " + this.gameObject.name);
    }

    

}
