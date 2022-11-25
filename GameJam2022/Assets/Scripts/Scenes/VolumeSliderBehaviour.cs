using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderBehaviour : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(MixerConstants.volume, 0.75f);
    }
    public void SetVolume()
    {
        //audioMixer.SetFloat(MixerConstants.volume, volume);
        //Debug.Log(volume);
        float sliderValue = slider.value;
        audioMixer.SetFloat(MixerConstants.volume, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(MixerConstants.volume, sliderValue);
    }
}
