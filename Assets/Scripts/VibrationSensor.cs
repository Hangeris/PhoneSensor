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
    

    public void Vibrate()
    {
        Vibration.Vibrate(50, -1, true);
    }
    

}
