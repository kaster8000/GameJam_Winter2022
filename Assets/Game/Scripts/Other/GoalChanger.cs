using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalChanger : MonoBehaviour
{
    GameManager M_GameManager;
    MusicController M_MusicController;
    public string LoadSceneName;
    void Start()
    {
        M_GameManager = FindObjectOfType<GameManager>();
        M_MusicController = M_GameManager.GlobalMusicController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && M_GameManager.GoalUnlocked)
        {
            M_MusicController.StopAllMusic();
            SceneManager.LoadScene(LoadSceneName);
        }
    }
}
