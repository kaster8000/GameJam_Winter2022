
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    bool FlashTogle;
    public TextMeshProUGUI Flashtext;

    private void Start()
    {
        if(PlayerPrefs.GetInt("FlashSave") == 0)
        {
            FlashTogle = false;
            Flashtext.SetText("Disabled");
        }
        else if (PlayerPrefs.GetInt("FlashSave") == 1)
        {
            FlashTogle = true;
            Flashtext.SetText("Enabled");
        }
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
