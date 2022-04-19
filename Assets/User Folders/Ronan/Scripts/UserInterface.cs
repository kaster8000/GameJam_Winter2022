using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UserInterface : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
