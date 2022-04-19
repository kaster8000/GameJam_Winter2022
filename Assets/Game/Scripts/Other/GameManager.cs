using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool GoalUnlocked;
    public int PickUpCount;
    int TotalFoundPickUp;
    public GameObject PauseCanvas;
    public GameObject PauseLayout;
    public GameObject OptionsLayout;
    public TextMeshProUGUI Flashtext;
    bool IsGamePaused;
    bool FlashTogle;
    private void Start()
    {
        if (PlayerPrefs.GetInt("FlashSave") == 0)
        {
            FlashTogle = false;
            Flashtext.SetText("Disabled");
        }
        else if (PlayerPrefs.GetInt("FlashSave") == 1)
        {
            FlashTogle = true;
            Flashtext.SetText("Enabled");
        }
        PauseCanvas.SetActive(false);
        OptionsLayout.SetActive(false);
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
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void TogleOptions(bool i)
    {
        OptionsLayout.SetActive(i);
        PauseLayout.SetActive(!i);
    }
    public void Flash()
    {
        if (FlashTogle)
        {
            // disable
            Flashtext.SetText("Disabled");
            PlayerPrefs.SetInt("FlashSave", 0);
            FlashTogle = false;
        }
        else
        {
            // enable
            Flashtext.SetText("Enabled");
            PlayerPrefs.SetInt("FlashSave", 1);
            FlashTogle = true;
        }
    }
}
