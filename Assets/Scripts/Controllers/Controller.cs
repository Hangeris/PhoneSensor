using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] GyroSensor gyroSensor;
    [SerializeField] VibrationSensor vibrationSensor;
    [SerializeField] UIController uiController;
    [SerializeField] BlinkEffect blinkEffect;
    

    List<Ball> balls = new List<Ball>();


    public void ChangeBallVisibility(bool areVisible)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].meshRenderer.enabled = areVisible;
        }
    }

    public void Register(Ball ball)
    {
        balls.Add(ball);
    }
    
    public void BallCollisionEnter(Color ballColor)
    {
        if (uiController.vibrationToggle.isOn)
            vibrationSensor.Vibrate();
        
        if (uiController.blinkEffectToggle)
            blinkEffect.Blink(ballColor);
        //
        // if (uiController.vibrationToggle.isOn)
        //     vibrationSensor.Vibrate();
    }
    
}
