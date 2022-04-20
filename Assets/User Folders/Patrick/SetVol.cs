using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SetVol : MonoBehaviour
{
    public TextMeshProUGUI textVol;
    public AudioMixer mixer;
    public Slider slider;
    public float textVolMath;
    public string MixerStringVolName;
    public string PlayerPrefString;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(PlayerPrefString, 0.75f);
        textVol.SetText("" + textVolMath.ToString("f0") + "%");
        UpdateSound();

    }
    public void UpdateSound()
    {
        Debug.Log("Called UpdateSound");
        slider.value = PlayerPrefs.GetFloat(PlayerPrefString, 0.75f);
        textVol.SetText("" + textVolMath.ToString("f0") + "%");
        float sliderValue = slider.value;
        mixer.SetFloat(MixerStringVolName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(PlayerPrefString, sliderValue);
        textVolMath = sliderValue * 100f;
        textVol.SetText("" + textVolMath.ToString("f0") + "%");
    }

    public void SetLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat(MixerStringVolName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(PlayerPrefString, sliderValue);

        textVolMath = sliderValue * 100f;
        textVol.SetText("" + textVolMath.ToString("f0") + "%");

        

    }
}
