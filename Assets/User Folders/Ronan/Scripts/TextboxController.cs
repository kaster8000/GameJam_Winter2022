using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextboxController : MonoBehaviour
{

    [Header("textbox animations and control")]
    public GameObject[] texts;
    public Animator textbox;
    Animator thisAnim;
    int currentText = 0;

    [Header("External Game Refs")]
    public PlayerMovement pm;
    public LightningController lc;
    public AIMovement aiMove;
    public Animator extAnim;
    public string extAnimName;
    public GameObject[] gameObjectsToActivate;
    //public GameObject cinematicBars;

    //for if you need to invoke a method from this script
    public string[] invokeMethodOnEnd;
    public float invokeTime;

    // Start is called before the first frame update
    void Start()
    {
        //cinematicBars.SetActive(true);
        pm.CanMove = false;
        thisAnim = GetComponent<Animator>();
        currentText = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScrollText();
        }
    }

    void ScrollText()
    {
        textbox = texts[currentText].GetComponent<Animator>();
        textbox.Play("Textbox_FadeOut");
        currentText++;
        if (currentText >= texts.Length)
        {
            currentText--;
            thisAnim.SetTrigger("TriggerFade");
            Destroy(gameObject, 0.12f);
            //cinematicBars.SetActive(false);
            pm.CanMove = true;
            if (invokeMethodOnEnd.Length != 0)
            {
                foreach (string str in invokeMethodOnEnd)
                {
                    Invoke(str, invokeTime);
                } 
            }
        }
        texts[currentText].SetActive(true);

    }

    void PlayAnim()
    {
        extAnim.Play(extAnimName);
    }

    void SetActive()
    {
        foreach (GameObject go in gameObjectsToActivate)
        {
            go.SetActive(true);
        }
    }

    void ActivateAI()
    {
        aiMove.CanTargetPlayer = true;
    }

    void TriggerLightning()
    {
        lc.SetNextInterval(Time.time + 3f);
    }
}
