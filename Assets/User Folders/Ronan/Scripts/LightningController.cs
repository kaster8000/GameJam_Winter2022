using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //timer floats
    float timeInterval;
    float nextInterval;

    // Start is called before the first frame update
    void Start()
    {
        timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if ((nextInterval - Time.time) <= 3)
        {
            //play lightning audio cue
        }

        if (Time.time > nextInterval)
        {
            //play lightning strike
            timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
            nextInterval = Time.time + timeInterval;
        }
    }
}
