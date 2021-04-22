using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    private GameObject VolumeText;
    private TMP_Text CurrVolumeText;
    private float SliderValue;
    Slider VolumeSlider;

    void Awake()
    {
        VolumeText = transform.Find("VolumeValue").gameObject;
        CurrVolumeText = VolumeText.GetComponent<TMP_Text>();
        VolumeSlider = GetComponent<Slider>();
    }
    public void OnVolumeChange()
    {
        if (VolumeSlider == null)
        {
            return;
        }
        SliderValue = VolumeSlider.value;
        CurrVolumeText.text = Math.Round(SliderValue * 100).ToString();
        //Debug.Log("Curr slider value: "+ SliderValue.ToString());
    }
}
