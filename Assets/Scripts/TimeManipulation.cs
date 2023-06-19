using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class TimeManipulation : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    Slider slider;
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    TMP_Text speedText;
    [SerializeField]
    Camera mainCam;

    float fixedTime = 0f;
    float maxfixedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        fixedTime = Time.fixedDeltaTime;
        maxfixedTime = Time.fixedDeltaTime;

        SetSlider();
        ChangeBgColor();
    }

    private void SetSlider()
    {
        slider.maxValue = 10f;
        slider.minValue = 0.0f;
        slider.value = 1f;
    }

    public void ChangeTimeScale()
    {
        speedText.text = slider.value.ToString("N2");

        Time.timeScale = slider.value;
        //Time.fixedDeltaTime = Math.Clamp(fixedTime * Time.timeScale, 0f, maxfixedTime);

        audioMixer.SetFloat("Pitch", slider.value);

        //ChangeBgColor();
    }

    void ChangeBgColor()
    {
        float lerpValue = Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);
        mainCam.backgroundColor = Color.Lerp(new Color(0.14f, 0.19f, 0.19f), new Color(0.3f, 0.18f, 0f, 1f), lerpValue);
    }
}
