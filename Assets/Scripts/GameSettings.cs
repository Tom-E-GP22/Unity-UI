using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static float volume = 100;
    Slider volumeSlider;
    TextMeshProUGUI volumeValue;


    void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        volumeValue = GameObject.Find("VolumeValue").GetComponent<TextMeshProUGUI>();
        volumeSlider.value = volume;
        volumeValue.text = volume.ToString() + "%"; 
    }

    public void ChangeVolume()
    {
        volume = volumeSlider.value;
        volumeValue.text = volume.ToString() + "%"; 
    }
}
