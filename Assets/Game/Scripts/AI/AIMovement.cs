using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AIMovement : MonoBehaviour
{
    public bool CanTargetPlayer;
    public bool GoForPlayer;
    public float PlayerHuntingSpeed;
    public float NromalHuntingSpeed;
    GameObject Player;

    AIDestinationSetter M_AIDestinationSetter;
    AIPath M_AIPath;
    public bool RandomStart;
    public List<GameObject> ObjectPoints;
    public int ObjectInt;
    bool CanChange;

    void Start()
    {
        
        if(RandomStart)
        {
            ObjectInt = Random.Range(0, ObjectPoints.Count);
        }
        // gets refreces for the player, AIDestinationSetter, and AIPath
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        M_AIDestinationSetter = GetComponent<AIDestinationSetter>();
        M_AIPath = GetComponent<AIPath>();
    }


    void FixedUpdate()
    {


        // changes the behavior of the AI deping on this bool 
        if (GoForPlayer == false)
        {

            // set the speed when the AI is not hunting the player
            M_AIPath.maxSpeed = NromalHuntingSpeed;

            // set the AI target to the game object in the array 
            M_AIDestinationSetter.target = ObjectPoints[ObjectInt].transform;
            // checks to see if the AI is at the Object in the arry then change the object to target
            if (M_AIPath.remainingDistance <= 1 && CanChange) 
            {

                if (ObjectInt != ObjectPoints.Count - 1)
                {

                    ObjectInt++;
                    

                }
                else
                {
      
                    ObjectInt = 0;
                }
                CanChange = false;
            }
            else
            {
                CanChange = true;
            }
        }
        else
        {

            // gose ham on player
            M_AIPath.maxSpeed = PlayerHuntingSpeed;
            M_AIDestinationSetter.target = Player.transform;
        }
    }


    // togle when the player gets hunted
    public void TogleHuntingPlayer(bool i)
    {
        //Debug.Log("Called " + i);
        if(CanTargetPlayer)
            GoForPlayer = i;
    }

}
