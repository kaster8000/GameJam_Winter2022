using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] SoundsList;
    

    public static AudioManager instance;
    private void Awake()
    {

        
       

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach(Sound s in SoundsList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.loop = s.IsLoop;
        }
    }


    public void PlaySound(string name)
    {
        Sound s = Array.Find(SoundsList, Sound => Sound.Name == name);
        
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " Not found!");
            return;
        }
        s.source.Play();
    }


    public void PlaySoundWait(string name)
    {
        Sound s = Array.Find(SoundsList, Sound => Sound.Name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " Not found!");
            return;
        }
        if(s.source.isPlaying)
        {

        }
        else
            s.source.Play();
    }


    public void StopSound(string name)
    {
        Sound s = Array.Find(SoundsList, Sound => Sound.Name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " Not found!");
            return;
        }
        
        s.source.Stop();
    }

}
