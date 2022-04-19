using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UserInterface : MonoBehaviour
{

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
