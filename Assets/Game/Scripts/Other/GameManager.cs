using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioManager GlobalAudioManager;
    public MusicController GlobalMusicController;

    public bool GoalUnlocked;
    public int PickUpCount;
    int TotalFoundPickUp;
    public GameObject PauseCanvas;
    public GameObject PauseLayout;
    public GameObject OptionsLayout;
    public TextMeshProUGUI Flashtext;
    bool IsGamePaused;
    public bool CanPause = true;
    bool FlashTogle;
    private void Awake()
    {

        GlobalAudioManager = FindObjectOfType<AudioManager>();
        GlobalMusicController = FindObjectOfType<MusicController>();
        //CanPause = true;

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

        if (GlobalMusicController.Music[GlobalMusicController.FindVal("MainMenu")].source.isPlaying)
            GlobalMusicController.StopMusic("MainMenu");

        if(!GlobalMusicController.Music[GlobalMusicController.FindVal("Rain")].source.isPlaying)
            GlobalMusicController.PlayeMusic("Rain");
        if(!GlobalMusicController.Music[GlobalMusicController.FindVal("BGM")].source.isPlaying)
            GlobalMusicController.PlayeMusic("BGM");



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

        if (PickUpCount >= TotalFoundPickUp)
        {
            GoalUnlocked = true;
            GlobalAudioManager.PlaySound("PickupsDone");
        }
    }

    public void PauseTogle(bool pauseState)
    {
        IsGamePaused = pauseState;
        if(CanPause)
        {
            if (IsGamePaused)
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
        
    }
    public void Replay()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        GlobalMusicController.StopAllMusic();
        Time.timeScale = 0.2f;
        Invoke("MainMenuDelay", 0.1f);
    }
    public void MainMenuDelay()
    {
        Time.timeScale = 1;
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
