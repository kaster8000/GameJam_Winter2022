using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public int DamageTaken;
    public float HitDelay;
    float HitInterval;

    void Start()
    {
        Health = MaxHealth;
        HitInterval = Time.time + HitDelay;
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
                GetComponent<PlayerMovement>().TogleCanMove(false);
                // play partical or animation
                Time.timeScale = 0;
                Invoke("DeathMenu", 1);
            }

        }
       
    }
    public void DeathMenu()
    {
        // show death menu 
    }

}
