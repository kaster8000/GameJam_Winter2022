using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUiInfo : MonoBehaviour
{
    public TextMeshProUGUI LevelNameTMP;
    public TextMeshProUGUI LevelDesTMP;
    public GameObject isPlayedGO;
    public Image Icon;
    public Button SelectorButton;

    //[HideInInspector]
    //public LevelData M_levelData;


    private string SceneName;
    public void Initalize(Levels M_levelData)
    {
        LevelNameTMP.text = M_levelData.levelName;
        Icon.sprite = M_levelData.levelIcon;

        SceneName = M_levelData.sceneName;
        SelectorButton.onClick.AddListener(LoadSelectedLevel);


    }

    void LoadSelectedLevel()
    {
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName);


    }
}
