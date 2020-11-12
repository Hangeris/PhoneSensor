using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Controller controller;
    
    public Toggle ballVisibilityToggle;
    public Toggle vibrationToggle;
    public Toggle blinkEffectToggle;
    public Toggle audioEffectToggle;
    
    void Awake()
    {
        ballVisibilityToggle.onValueChanged.AddListener(HandleBallVisibilityToggleChange);
        vibrationToggle.onValueChanged.AddListener(HandleVibrationToggleChange);
        blinkEffectToggle.onValueChanged.AddListener(HandleBlinkEffectToggleChange);
        audioEffectToggle.onValueChanged.AddListener(HandleAudioToggleChange);
    }

    void Start()
    {
        HandleBallVisibilityToggleChange(false);
        HandleVibrationToggleChange(false);
        HandleBlinkEffectToggleChange(false);
        HandleAudioToggleChange(false);
    }

    void HandleBallVisibilityToggleChange(bool isOn)
    {
        ballVisibilityToggle.isOn = isOn;
        controller.ChangeBallVisibility(isOn);
        Debug.Log("Ball Visibility toggle changed");
        
    }
    
    void HandleVibrationToggleChange(bool isOn)
    {
        vibrationToggle.isOn = isOn;
        Debug.Log("Vibration toggle changed");
        
    }
    
    void HandleBlinkEffectToggleChange(bool isOn)
    {
        blinkEffectToggle.isOn = isOn;
        Debug.Log("Blink Effect toggle changed");
        
    }
    
    public void HandleAudioToggleChange(bool isOn)
    {
        audioEffectToggle.isOn = isOn;
        Debug.Log("Audio toggle changed");
        
    }

    public void GuessPressed(int guess = -1)
    {
        if (guess == -1)
        {
            Debug.Log("Kas cia");
            return;
        }

        controller.Guess(guess);

    }

}
