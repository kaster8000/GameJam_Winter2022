using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    //public bool ChangeTarget;
    //public GameObject Test;
    //public GameObject Test2;
    //public AIDestinationSetter m_AIDestinationSetter;
    public AIPath m_AIPath;

   
    void Update()
    {
        if(m_AIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if(m_AIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }

        //if(ChangeTarget == false)
        //{
        //    m_AIPath.maxSpeed = 8;
        //    m_AIDestinationSetter.target = Test.transform;
        //}
        //else
        //{
        //    m_AIPath.maxSpeed = 18;
        //    m_AIDestinationSetter.target = Test2.transform;
        //}

    }
}
