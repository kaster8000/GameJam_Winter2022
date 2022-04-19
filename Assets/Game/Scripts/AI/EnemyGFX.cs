using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{

    AIPath M_AIPath;
    private void Start()
    {
        M_AIPath = GetComponentInParent<AIPath>();
    }

    void Update()
    {
        if(M_AIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else if(M_AIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }

        

    }
}
