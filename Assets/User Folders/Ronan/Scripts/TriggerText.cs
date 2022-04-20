using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public GameObject narrativeText;
    public float invokeTime = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("Active", invokeTime);
        }
    }

    void Active()
    {
        narrativeText.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
