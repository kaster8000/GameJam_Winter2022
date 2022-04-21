using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class DoorController : MonoBehaviour
{
    GameManager M_GameManager;
    AudioManager M_AudioManager;
    public GameObject DoorPair;
    bool isOpen = false;

    private void Start()
    {
        M_GameManager = FindObjectOfType<GameManager>();
        M_AudioManager = M_GameManager.GlobalAudioManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if(isOpen == false)
        {
            isOpen = true;
            var temp = DoorPair.GetComponent<Animator>();
            if(temp == null)
                DoorPair.SetActive(false);
            else
                temp.SetTrigger("DoorSwitch");
            M_AudioManager.PlaySound("Pad Unlocked");
            Invoke("GridUpdate", 1);
        }
        
    }
    void GridUpdate()
    {
        var GraphToScan = AstarPath.active.data.gridGraph;
        Debug.Log(GraphToScan);
        AstarPath.active.Scan(GraphToScan);
    }
}
