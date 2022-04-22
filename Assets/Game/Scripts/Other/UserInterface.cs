
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class UserInterface : MonoBehaviour
{
    MusicController M_MusicController;
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    bool FlashTogle;
    public TextMeshProUGUI Flashtext;

    private void Start()
    {
        M_MusicController = FindObjectOfType<MusicController>();

        if (!M_MusicController.Music[M_MusicController.FindVal("MainMenu")].source.isPlaying && M_MusicController!= null)
        {
            M_MusicController.PlayeMusic("MainMenu");
        }
        
        
        if (Flashtext != null)
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
        }
        else
            Debug.Log("Flashtext = Null");
        
        if(OptionsMenu != null)
            OptionsMenu.SetActive(false);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void TogleOptions(bool i)
    {
        OptionsMenu.SetActive(i);
        MainMenu.SetActive(!i);
    }

    public void Flash()
    {
        if(FlashTogle)
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
