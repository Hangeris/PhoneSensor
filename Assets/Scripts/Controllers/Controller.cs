using System;
using System.Collections;
using System.Collections.Generic;
using Hellmade.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GyroSensor gyroSensor;
    [SerializeField] VibrationSensor vibrationSensor;
    [SerializeField] UIController uiController;
    [SerializeField] BlinkEffect blinkEffect;

    [Header("Audio")] 
    [SerializeField] AnimationCurve audioVolumeCurve;
    
    List<Ball> balls = new List<Ball>();

    public void ChangeBallVisibility(bool areVisible)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].meshRenderer.enabled = areVisible;
        }
    }

    public void BTN_Restart()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Register(Ball ball)
    {
        balls.Add(ball);
    }

    public void BallCollisionEnter(Color ballColor, AudioClip audioClip, float collisionForce)
    {
        if (uiController.vibrationToggle.isOn)
            vibrationSensor.Vibrate();
        
        if (uiController.blinkEffectToggle.isOn)
            blinkEffect.Blink(ballColor);

        if (uiController.audioEffectToggle.isOn)
        {
            var volume = audioVolumeCurve.Evaluate(collisionForce);
            EazySoundManager.PlaySound(audioClip, volume);
        }
    }
    
}
