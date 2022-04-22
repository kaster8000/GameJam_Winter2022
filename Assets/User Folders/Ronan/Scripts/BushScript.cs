using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{
    GameManager M_GameManager;
    AudioManager M_AudioManager;
    ParticleSystem bushPS;
    // Start is called before the first frame update
    void Start()
    {
        M_GameManager = FindObjectOfType<GameManager>();
        M_AudioManager = M_GameManager.GlobalAudioManager;
        bushPS = GetComponentInChildren<ParticleSystem>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("BushEnter");
            M_AudioManager.PlaySound("BushEnter");
            bushPS.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print(" BushExit");
            M_AudioManager.PlaySound("BushExit");
            bushPS.Play();
        }
    }
}
