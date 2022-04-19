using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

/*
 randomly generate a time for lightning to strike 
 audio cue when 3 secs before timer
 when at 0, flash light 
 */
public class LightningController : MonoBehaviour
{
    //set min-max floats for lightning strike intervals
    public float minTimeInterval = 4f;
    public float maxTimeInterval = 10f;
    public float EnemyHuntingTime;

    [Header("Lightning Light Intesities")]
    public float flashIntensity;
    public float warningIntensity;
    public float fallOffSpeed;
    public float increaseSpeed;

    //timer floats
    float timeInterval;
    float nextInterval;
    float HuntInterval;
    // lets me know when Lighting flashed so the hunting timer can tic down
    [HideInInspector]
    public bool LightingFlashed;
    public Light2D lightningLight;

    // Start is called before the first frame update
    void Start()
    {
        timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
        nextInterval = Time.time + timeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //warning
        if ((nextInterval - Time.time) <= 3)
        {
            //play lightning audio cue
            lightningLight.intensity = Mathf.Lerp(lightningLight.intensity, warningIntensity, increaseSpeed * Time.deltaTime);
            //Debug.Log("warning");
        }
        //base
        else if (Time.time < nextInterval)
        {
            lightningLight.intensity = Mathf.Lerp(lightningLight.intensity, 0f, fallOffSpeed * Time.deltaTime);
            //Debug.Log("base");

        }
        //flash
        if (Time.time > nextInterval)
        {
            //play lightning strike
            lightningLight.intensity = flashIntensity;
            timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
            nextInterval = Time.time + timeInterval;
            HuntInterval = Time.time + EnemyHuntingTime;
            //Debug.Log("flash");
            LightingFlashed = true;
            UpdateEnemys(true);
        }
        if(lightningLight == true && Time.time > HuntInterval)
        {
            //Debug.Log("lightningLight");
            LightingFlashed = false;
            UpdateEnemys(false);
        }

    }

    void UpdateEnemys(bool i)
    {
        var temp = FindObjectsOfType<AIMovement>();
        foreach(AIMovement g in temp)
        {
            g.TogleHuntingPlayer(i);
        }
    }


}
