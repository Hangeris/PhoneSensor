using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] Transform gameEndPanel;
    [SerializeField] TMP_InputField nameInputField;
    void Awake()
    {
        gameEndPanel.gameObject.SetActive(false);
    }


    public void Show()
    {
        Time.timeScale = 0;
        gameEndPanel.gameObject.SetActive(true);
    }

    public void BTN_Submit()
    {
        Time.timeScale = 1;
        Debug.Log($"Score submitted: {nameInputField.text}");
        SceneManager.LoadScene(0);

    }
    
}
