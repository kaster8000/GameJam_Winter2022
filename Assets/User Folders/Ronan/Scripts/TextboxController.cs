using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxController : MonoBehaviour
{

    //textbox animations and control
    public GameObject[] texts;
    public Animator textbox;
    Animator thisAnim;
    int currentText = 0;

    //external game references for choreography
    public PlayerMovement pm;
    public LightningController lc;
    public AIMovement aiMove;
    public Animator globalAnim;
    public GameObject[] gameObjectsToActivate;
    //public GameObject cinematicBars;

    //for if you need to invoke a method from this script
    public string[] invokeMethodOnEnd;

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
                    Invoke(str, 0);
                } 
            }
        }
        texts[currentText].SetActive(true);

    }

    void SetGlobalAnim()
    {
        globalAnim.Play("Test2");
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
        lc.SetNextInterval(3);
    }
}
