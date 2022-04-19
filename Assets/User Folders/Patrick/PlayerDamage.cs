using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public int DamageTaken;


    void Start()
    {
        Health = MaxHealth;
    }


    private void OnTriggerEnter2D(Collider2D collision)
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
        // the logic for damage 
        Health = Health - i;
        if(Health <= 0)
        {
            Debug.Log("Dead");
            // play partical or animation
            Invoke("DeathMenu", 1);
        }
    }
    public void DeathMenu()
    {
        // how death menu 
    }

}
