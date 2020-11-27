using System;
using System.Collections;
using System.Collections.Generic;
using Hellmade.Sound;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] UnityEvent[] timeHelpers;

    [Header("References")]
    [SerializeField] GyroSensor gyroSensor;
    [SerializeField] VibrationSensor vibrationSensor;
    [SerializeField] BlinkEffect blinkEffect;

    [Header("Audio")] 
    [SerializeField] AnimationCurve audioVolumeCurve;
    
    List<Ball> balls = new List<Ball>();
    int generatedBallAmount = 0;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        FindObjectOfType<ObjectSpawner>().Init();
        
        ChangeBallVisibility(UIController.AreBallsVisible);
    }
    
    public void Guess(int guess)
    {
        var time = FindObjectOfType<Timer>().timer;

        if (guess == generatedBallAmount)
        {
            Debug.Log($"You are correct! Your time is: {time:F1}");
        }
        else
        {
            Debug.Log($"You are incorrect! Your time is: {time:F1}");
        }

        FindObjectOfType<GameEndPanel>().Show();
    }
    
    public void Help(int currentHelp)
    {
        if (timeHelpers.Length <= currentHelp)
            return;
        
        timeHelpers[currentHelp].Invoke();
        currentHelp++;
    }
    
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
        generatedBallAmount++;
    }

    public void BallCollisionEnter(Color ballColor, AudioClip audioClip, float collisionForce)
    {
        if (UIController.IsVibrationActive)
            vibrationSensor.Vibrate();
        
        if (UIController.IsBlinkEffectActive)
            blinkEffect.Blink(ballColor);

        if (UIController.IsSoundActive)
        {
            var volume = audioVolumeCurve.Evaluate(collisionForce);
            EazySoundManager.PlaySound(audioClip, volume);
        }
    }
    
}
