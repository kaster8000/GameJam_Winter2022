using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public List<Sound> Music;



    public static MusicController instance;
    private void Awake()
    {



        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in Music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.loop = s.IsLoop;
        }
    }

    public void PlayeMusic(string name)
    {
        foreach (Sound s in Music)
        {
            if (s.Name == name)
            {
                s.source.Play();
                break;
            }
        }
    }

    public void StopMusic(string name)
    {
        foreach (Sound s in Music)
        {
            if (s.Name == name)
            {
                s.source.Stop();
                break;
            }
        }
    }

    

    public int FindVal(string Name)
    {
        var temp = -1;
        
        foreach (Sound s in Music)
        {
            //Debug.Log("Entered Loop");
            if (s.Name == Name)
            {
                Music.IndexOf(s);

                //Debug.Log(Music.IndexOf(s));
                //Debug.Log(s.Name);
                temp = Music.IndexOf(s);

                break;
            }
            

        }
        return temp;

    }


    
}
