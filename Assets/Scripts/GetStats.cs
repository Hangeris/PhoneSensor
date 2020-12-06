using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GetStats : MonoBehaviour
{

    void Start()
    {
        

        //ShowDataWinrate(allUsers);
    }


    void ShowDataWinrate(AllUsers allUsers)
    {
        foreach (var userData in allUsers.userDatas)
        {
            Debug.Log("----------------");
            var userName = userData.name;
  
            foreach (var gameData in userData.gameDatas)
            {
                var nameOfGameType = GetNameByGameType(gameData);
                Debug.Log($"Game type name: {nameOfGameType}");
                int amountOfCorrect = 0;
                int amountOfIncorrect = 0;
                
                foreach (var specificGame in gameData.specificGameDatas)
                {
                    var specificGameTime = specificGame.time;
                    var specificGameIsCorrect = specificGame.isCorrect;
                    if (specificGameIsCorrect)
                    {
                        amountOfCorrect++;
                    }
                    else
                    {
                        amountOfIncorrect++;
                    }
                }
                
                
                
            }
            print("Saved users: " + userName);
        }
    }


    string GetNameByGameType(GameData gameData)
    {
        if (gameData.areBallsVisible)
            return "Balls visible";

        
        if (gameData.isSoundActive && !gameData.isVibrationActive && !gameData.isBlinkEffectActive)
            return "Only sound";
        
        if (!gameData.isSoundActive && gameData.isVibrationActive && !gameData.isBlinkEffectActive)
            return "Only vibration";
        
        if (!gameData.isSoundActive && !gameData.isVibrationActive && gameData.isBlinkEffectActive)
            return "Only blink effect";
        
        
        if (gameData.isSoundActive && gameData.isVibrationActive && !gameData.isBlinkEffectActive)
            return "Sound, vibration";
        
        if (gameData.isSoundActive && !gameData.isVibrationActive && gameData.isBlinkEffectActive)
            return "Sound, blink effect";
        
        if (!gameData.isSoundActive && gameData.isVibrationActive && gameData.isBlinkEffectActive)
            return "Vibration, blink effect";
        
        
        if (gameData.isSoundActive && gameData.isVibrationActive && gameData.isBlinkEffectActive)
            return "Sound, vibration, blink effect";

        return "Unknown type";

    }
    
}
