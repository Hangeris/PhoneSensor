using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static bool AreBallsVisible;
    public static bool IsVibrationActive;
    public static bool IsBlinkEffectActive;
    public static bool IsSoundActive;
    
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
        GameData gameData = new GameData(false, false, false, true);
        GameData gameData2 = new GameData(false, true, false, false);
        Debug.Log(gameData.Equals(gameData2));
        
        HandleBallVisibilityToggleChange(false);
        HandleVibrationToggleChange(false);
        HandleBlinkEffectToggleChange(false);
        HandleAudioToggleChange(false);
        
        AreBallsVisible = false;
        IsVibrationActive = false;
        IsBlinkEffectActive = false;
        IsSoundActive = false;
    }

    void HandleBallVisibilityToggleChange(bool isOn)
    {
        ballVisibilityToggle.isOn = isOn;
        AreBallsVisible = isOn;
    }
    
    void HandleVibrationToggleChange(bool isOn)
    {
        vibrationToggle.isOn = isOn;
        IsVibrationActive = isOn;
    }
    
    void HandleBlinkEffectToggleChange(bool isOn)
    {
        blinkEffectToggle.isOn = isOn;
        IsBlinkEffectActive = isOn;

    }
    
    public void HandleAudioToggleChange(bool isOn)
    {
        audioEffectToggle.isOn = isOn;
        IsSoundActive = isOn;

    }

    public void GuessPressed(int guess = -1)
    {
        if (guess == -1)
        {
            return;
        }

        //controller.Guess(guess);

    }

    public void BTN_Play()
    {
        StartCoroutine(FindObjectOfType<GameManager>().EnterPlayRoutine());
    }
    
    public void BTN_Stats()
    {
        StartCoroutine(FindObjectOfType<GameManager>().EnterStatsRoutine());
    }
    
    

}
