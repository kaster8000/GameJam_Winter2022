using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    
    GameManager M_GameManager;

    void Start()
    {
        M_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            M_GameManager.AddPickUpCounter(1);
            Destroy(this.transform.root.gameObject);
        }
    }
}
