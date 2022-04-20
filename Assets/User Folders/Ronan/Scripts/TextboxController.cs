using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxController : MonoBehaviour
{
    //public playerControllerScript pc;
    //public GameObject cinematicBars;
    public GameObject[] texts;
    //public GameObject portal;
    public Animator globalAnim;
    public Animator textbox;
    Animator thisAnim;
    int currentText = 0;
    public string invokeMethodEnd;

    // Start is called before the first frame update
    void Start()
    {
        //cinematicBars.SetActive(true);
        //pc.canMove = false;
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
            //pc.canMove = true;
            if (invokeMethodEnd != string.Empty)
            {
                Invoke(invokeMethodEnd, 0);
            }
        }
        texts[currentText].SetActive(true);

    }

    void SetGlobalAnim()
    {
        globalAnim.Play("Test2");
    }
}
