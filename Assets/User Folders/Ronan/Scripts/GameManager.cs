using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GoalUnlocked;
    public int PickUpCount;
    int TotalFoundPickUp;
    public GameObject PauseCanvas;
    bool IsGamePaused;
    private void Start()
    {
        PauseCanvas.SetActive(false);
        GoalUnlocked = false;
        var temp = GameObject.FindGameObjectsWithTag("PickUp");
        foreach (GameObject i in temp)
        {
            TotalFoundPickUp++;
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTogle(true);
        }

        if (PickUpCount >= TotalFoundPickUp)
        {
            GoalUnlocked = true;
        }
    }

   
    public void AddPickUpCounter(int i)
    {
        PickUpCount = PickUpCount + i;
    }

    public void PauseTogle(bool pauseState)
    {
        IsGamePaused = pauseState;
        if(IsGamePaused)
        {
            // pause
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
            //unpause
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        // show options
    }
}
