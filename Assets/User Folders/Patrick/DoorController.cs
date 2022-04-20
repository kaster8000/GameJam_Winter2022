using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class DoorController : MonoBehaviour
{
    public GameObject DoorPair;
    bool isOpen = false;


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
            //DoorPair.SetActive(false);
            var temp = DoorPair.GetComponent<Animator>();
            temp.SetTrigger("DoorSwitch");

            Invoke("Test", 1);
        }
        
    }
    void Test()
    {
        var GraphToScan = AstarPath.active.data.gridGraph;
        Debug.Log(GraphToScan);
        AstarPath.active.Scan(GraphToScan);
    }
}
