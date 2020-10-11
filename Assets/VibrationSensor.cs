using System;
using System.Collections;
using System.Collections.Generic;
using RDG;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VibrationSensor : MonoBehaviour
{

    [SerializeField] Slider durationSlider;
    [SerializeField] Slider amplitudeSlider;
    
    [SerializeField] TMP_Text durationText;
    [SerializeField] TMP_Text amplitudeText;

    float startTime;
    float delay;
    
    
    void Start()
    {
        StartCoroutine(VibrationRoutine());
    }

    void Update()
    {
        durationText.text = $"Duration {(durationSlider.value)}ms";
        //amplitudeText.text = $"Amplitude {amplitudeSlider.value}";
    }

    public void BTN_Vibrate1()
    {
        Vibration.Vibrate((long)durationSlider.value, -1, true);
        startTime = Time.time;
        delay = durationSlider.value;
    }


    IEnumerator VibrationRoutine()
    {
        while (true)
        {
            yield return null;

            if (startTime + delay > Time.time)
            {
                //Handheld.Vibrate();
            }
        }
    }
    

}
