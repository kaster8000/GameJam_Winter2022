using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public GameObject narrativeText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            narrativeText.SetActive(true);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
