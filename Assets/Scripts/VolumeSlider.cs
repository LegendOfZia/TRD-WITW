using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.SetValueWithoutNotify(AudioManager.MusicVol);
    }

    public void VolSliderChange()
    {
        AudioManager.MusicVol = slider.value;
        Debug.Log("Music vol change: " + slider.value);
    }
}
