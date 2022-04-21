using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    
    GameManager M_GameManager;
    AudioManager M_AudioManager;
    GameObject progressBarObj;
    public Image progressImage;
    public float progressIncrement; //determines how fast progress bar fills up
    public bool isProgress;

    void Start()
    {
        M_GameManager = FindObjectOfType<GameManager>();
        M_AudioManager = M_GameManager.GlobalAudioManager;
        progressBarObj = progressImage.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isProgress)
        {
            progressBarObj.SetActive(true);
            progressImage.fillAmount = 0;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            M_GameManager.AddPickUpCounter(1);
            M_AudioManager.PlaySound("PickUpSound");
            Destroy(this.transform.root.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isProgress)
        {
            if (progressImage.fillAmount >= 1)
            {
                M_GameManager.AddPickUpCounter(1);
                M_AudioManager.PlaySound("PickUpSound");
                Destroy(this.transform.root.gameObject);
            }
            progressImage.fillAmount += progressIncrement;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isProgress)
        {
            progressBarObj.SetActive(false);
        }
    }
}
