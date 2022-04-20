using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip clip;
    public AudioSource source;
    public AudioMixerGroup mixer;
    public bool IsLoop;




}
