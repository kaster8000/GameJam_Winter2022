using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GoalUnlocked;
    public int PickUpCount;
    int TotalFoundPickUp;

    private void Start()
    {
        GoalUnlocked = false;
        var temp = GameObject.FindGameObjectsWithTag("PickUp");
        foreach (GameObject i in temp)
        {
            TotalFoundPickUp++;
        }
    }


    private void Update()
    {
        if (PickUpCount >= TotalFoundPickUp)
        {
            GoalUnlocked = true;
        }
    }

   
    public void AddPickUpCounter(int i)
    {
        PickUpCount = PickUpCount + i;
    }


}
