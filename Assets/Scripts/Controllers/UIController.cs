﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Controller controller;
    
    public Toggle ballVisibilityToggle;
    public Toggle vibrationToggle;
    public Toggle blinkEffectToggle;
    
    void Awake()
    {
        ballVisibilityToggle.onValueChanged.AddListener(HandleBallVisibilityToggleChange);
        vibrationToggle.onValueChanged.AddListener(HandleVibrationToggleChange);
        blinkEffectToggle.onValueChanged.AddListener(HandleBlinkEffectToggleChange);
    }

    
    void HandleBallVisibilityToggleChange(bool isOn)
    {
        controller.ChangeBallVisibility(isOn);
        Debug.Log("Ball Visibility toggle changed");
        
    }
    
    void HandleVibrationToggleChange(bool isOn)
    {
        Debug.Log("Vibration toggle changed");
        
    }
    
    void HandleBlinkEffectToggleChange(bool isOn)
    {
        Debug.Log("Blink Effect toggle changed");
        
    }

}