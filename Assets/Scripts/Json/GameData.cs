using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameData
{
    public bool areBallsVisible;
    public bool isVibrationActive;
    public bool isBlinkEffectActive;
    public bool isSoundActive;
    public List<SpecificGameData> specificGameDatas;

    public GameData(bool areBallsVisible, bool isVibrationActive, bool isBlinkEffectActive, bool isSoundActive)
    {
        this.areBallsVisible = areBallsVisible;
        this.isVibrationActive = isVibrationActive;
        this.isBlinkEffectActive = isBlinkEffectActive;
        this.isSoundActive = isSoundActive;
        specificGameDatas = new List<SpecificGameData>();
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        
        if (((GameData)obj).areBallsVisible == areBallsVisible && areBallsVisible)
            return true;
        
        return ((GameData)obj).areBallsVisible == areBallsVisible &&
               ((GameData)obj).isVibrationActive == isVibrationActive &&
               ((GameData)obj).isBlinkEffectActive == isBlinkEffectActive &&
               ((GameData)obj).isSoundActive == isSoundActive;
    }

    public void AddSpecificGame(SpecificGameData specificGameData)
    {
        specificGameDatas.Add(specificGameData);
    }
    
}

[System.Serializable]
public struct SpecificGameData
{
    public int time;
    public bool isCorrect;

    public SpecificGameData(int _time, bool _isCorrect)
    {
        time = _time;
        isCorrect = _isCorrect;
    }
}
