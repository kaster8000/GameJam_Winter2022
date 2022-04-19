using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalChanger : MonoBehaviour
{
    GameManager M_GameManager;
    public string LoadSceneName;
    void Start()
    {
        M_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && M_GameManager.GoalUnlocked)
        {
            SceneManager.LoadScene(LoadSceneName);
        }
    }
}
