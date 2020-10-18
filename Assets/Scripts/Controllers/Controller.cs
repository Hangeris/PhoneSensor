using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] GyroSensor gyroSensor;
    [SerializeField] VibrationSensor vibrationSensor;
    [SerializeField] UIController uiController;



    public void BallHit()
    {
        if (uiController.vibrationToggle.isOn)
            vibrationSensor.Vibrate();
        
        if (uiController.vibrationToggle.isOn)
            vibrationSensor.Vibrate();
        
        if (uiController.vibrationToggle.isOn)
            vibrationSensor.Vibrate();
    }
    
}
