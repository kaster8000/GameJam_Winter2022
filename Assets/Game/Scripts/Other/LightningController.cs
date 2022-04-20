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
    float CashedFlashIntensity;
    public float warningIntensity;
    float CashedWarningIntensity;
    public float fallOffSpeed;
    float CashedFallOffSpeed;
    public float increaseSpeed;
    float CashedIncreaseSpeed;

    //timer floats
    float timeInterval;
    float nextInterval;
    float HuntInterval;
    // lets me know when Lighting flashed so the hunting timer can tic down
    [HideInInspector]
    public bool LightingFlashed;
    public Light2D lightningLight;

    PlayerDamage M_PlayerDamage;
    GameManager M_GameManager;
    AudioManager M_AudioManager;


    // Start is called before the first frame update
    void Start()
    {
        M_PlayerDamage = FindObjectOfType<PlayerDamage>();
        M_GameManager = FindObjectOfType<GameManager>();
        if(M_GameManager != null)
            M_AudioManager = M_GameManager.GlobalAudioManager;

        timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
        nextInterval = Time.time + timeInterval;

        SaveStartinfo();
        UpdateFlash();



    }

    // Update is called once per frame
    void Update()
    {
        UpdateFlash();
        //warning
        if ((nextInterval - Time.time) <= 3f)
        {
            //play lightning audio cue
            lightningLight.intensity = Mathf.Lerp(lightningLight.intensity, warningIntensity, increaseSpeed * Time.deltaTime);
            if(M_AudioManager != null)
                M_AudioManager.PlaySound("ThunderWarning");
            Debug.Log("warning");
        }
        //base
        else if (Time.time < nextInterval)
        {
            lightningLight.intensity = Mathf.Lerp(lightningLight.intensity, 0f, fallOffSpeed * Time.deltaTime);
        }
        //flash
        if (Time.time >= nextInterval)
        {
            //play lightning strike
            if (M_AudioManager != null)
                M_AudioManager.PlaySound("ThunderStrike");
            lightningLight.intensity = flashIntensity;
            timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
            nextInterval = Time.time + timeInterval;
            HuntInterval = Time.time + EnemyHuntingTime;
            Debug.Log("flash");
            LightingFlashed = true;

             UpdateEnemys(true);

        }
        if(lightningLight == true && Time.time > HuntInterval)
        {
            //Debug.Log("lightningLight");
            LightingFlashed = false;
            UpdateEnemys(false);
        }
        else if(lightningLight == true && Time.time < HuntInterval)
        {
            if (M_PlayerDamage.InCover)
            {
                UpdateEnemys(false);
            }
            else
                UpdateEnemys(true);

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

    void SaveStartinfo()
    {
        CashedFallOffSpeed = fallOffSpeed;
        CashedFlashIntensity = flashIntensity;
        CashedIncreaseSpeed = increaseSpeed;
        CashedWarningIntensity = warningIntensity;

       
    }
    void UpdateFlash()
    {
        if (PlayerPrefs.GetInt("FlashSave") == 0)
        {
            // do normal settings
            flashIntensity = CashedFlashIntensity;
            warningIntensity = CashedWarningIntensity;
            fallOffSpeed = CashedFallOffSpeed;
            increaseSpeed = CashedIncreaseSpeed;

        }
        else if (PlayerPrefs.GetInt("FlashSave") == 1)
        {
            // do changed settings
            flashIntensity = 0.55f;
            warningIntensity = 0.65f;
            fallOffSpeed = 0.5f;
            increaseSpeed = 0.5f;
        }
    }

    public void SetNextInterval(float value)
    {
        nextInterval = value;
    }
}
