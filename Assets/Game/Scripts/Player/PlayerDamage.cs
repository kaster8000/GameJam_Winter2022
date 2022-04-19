using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerDamage : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public int DamageTaken;
    public float HitDelay;
    float HitInterval;
    public bool InCover;
    public LayerMask GroundCheck;
    void Start()
    {
        
        Health = MaxHealth;
        HitInterval = Time.time + HitDelay;
    }

    private void Update()
    {
        Collider2D GroundRay = Physics2D.OverlapCircle(this.transform.position, 0.2f, GroundCheck);
        if (GroundRay != null)
        {
            //Debug.Log("in Cover");
            InCover = true;
        }
        else
        {
            //Debug.Log("OutCover");
            InCover = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // checks if the enemy tag hits the player might be a bug if the same enemy bumps in to the player twice 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            TakePlayerDamage(DamageTaken);
        }
    }

    public void TakePlayerDamage(int i)
    {
        if(Time.time > HitInterval)
        {
            // the logic for damage 
            Health = Health - i;
            HitInterval = Time.time + HitDelay;
            if (Health <= 0)
            {
                Debug.Log("Dead");
                // stops player And Ai from moving  
                GetComponent<PlayerMovement>().TogleCanMove(false);
                var temp = FindObjectsOfType<AIPath>();
                foreach( AIPath t in temp)
                {
                    t.canMove = false;
                }
                // play partical or animation
                Invoke("DeathMenu", 1);
            }

        }
       
    }
    public void DeathMenu()
    {
        // show death menu 
    }

}
