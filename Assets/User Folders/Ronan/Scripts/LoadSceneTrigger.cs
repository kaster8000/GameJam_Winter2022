using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene", 0.5f);
    }

    void LoadScene()
    {
        UserInterface.LoadLevel("CreditsScene");
    }
}
