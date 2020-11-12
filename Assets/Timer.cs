using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    [SerializeField] TMP_Text timerText;
    [SerializeField] float timeUntilNextHelp = 5;
    
    public float timer = 0;
    float nextHelpTimer;
    int currentHelpIndex = 0;

    void Start()
    {
        Init();
    }

    void Init()
    {
        nextHelpTimer = GetNextTime();
        HandleNextHelp();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = $"{timer.ToString("F1")}s";

        if (IsNextTimeReady())
        {
            HandleNextHelp();
        }
        
    }

    void HandleNextHelp()
    {
        nextHelpTimer = GetNextTime();
        FindObjectOfType<Controller>().Help(currentHelpIndex++);
    }

    float GetNextTime()
    {
        return timer + timeUntilNextHelp;
    }
    
    bool IsNextTimeReady()
    {
        return timer >= nextHelpTimer;
    }
    
}
