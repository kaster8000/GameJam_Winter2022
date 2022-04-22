using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public List<Levels> LevelsList;
    public GameObject LevelItemUiprefab;
    public Transform LevelselectorUicontainer;


    private void Start()
    {
        AddLevel();
    }




    void AddLevel()
    {
        for (int i = 0; i < LevelsList.Count; i++)
        {
            GameObject go = Instantiate(LevelItemUiprefab, LevelselectorUicontainer);
            go.GetComponent<LevelUiInfo>().Initalize(LevelsList[i]);
        }

    }
}
