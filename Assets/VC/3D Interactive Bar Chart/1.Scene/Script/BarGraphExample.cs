using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using BarGraph.VittorCloud;

public class BarGraphExample : MonoBehaviour
{
    public List<BarGraphDataSet> exampleDataSet; // public data set for inserting data into the bar graph
    BarGraphGenerator barGraphGenerator; 

    void Start()
    {
        barGraphGenerator = GetComponent<BarGraphGenerator>();

        bool fileFound;
        var allUsers = ReadAllUsersJson(out fileFound);
        if (!fileFound)
        {
            Debug.Log("File was not found");
            return;
        }
        
        
        
        //exampleDataSet = new List<BarGraphDataSet>();
        
        //exampleDataSet.Add();
        
        //if the exampleDataSet list is empty then return.

    }

    public void ShowStatsFromGivenPlayer(AllUsers allUsers, int givenUserId)
    {
        var specificUser = GetSpecificUser(allUsers, givenUserId);

        Debug.Log("-----------");
        GameData mockedGameData;
        for (int i = 0; i < exampleDataSet.Count; i++)
        {
            var gameDataTypeIndex = i;
            mockedGameData = GetMockedGameDataByIndex(gameDataTypeIndex);
            var currentGameData = GetCurrentGameData(specificUser, mockedGameData);
            
            var barIndex = 0;    // 0 = winrate, 1 = games played
            var winRate = GetWinrate(currentGameData);
            exampleDataSet[gameDataTypeIndex].ListOfBars[barIndex].YValue = winRate;
            
            barIndex = 1;    // 0 = winrate, 1 = games played
            var playedAmount = GetTotalPlayed(currentGameData);
            exampleDataSet[gameDataTypeIndex].ListOfBars[barIndex].YValue = playedAmount;
        }
        
        if (exampleDataSet.Count == 0)
        {
            Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        barGraphGenerator.GeneratBarGraph(exampleDataSet);
    }
    
    GameData GetCurrentGameData(UserData userData, GameData mockedGameData)
    {
        foreach (var gameData in userData.gameDatas)
        {
            if (mockedGameData.Equals(gameData))
            {
                return gameData;
            }
        }

        return mockedGameData;
    }

    int GetWinrate(GameData currentGameData)
    {
        int amountOfCorrect = 0;
        int amountOfIncorrect = 0;

        if (currentGameData.specificGameDatas == null)
            return 0;
        
        foreach (var specificGame in currentGameData.specificGameDatas)
        {
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

        return (int)(((float)amountOfCorrect / (float)(amountOfCorrect + amountOfIncorrect))*100f);
    }
    
    int GetTotalPlayed(GameData currentGameData)
    {
        int amountOfCorrect = 0;
        int amountOfIncorrect = 0;

        if (currentGameData.specificGameDatas == null)
            return 0;
        
        foreach (var specificGame in currentGameData.specificGameDatas)
        {
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

        return (int)amountOfCorrect+amountOfIncorrect;
    }

    GameData GetMockedGameDataByIndex(int i)
    {
        GameData gameData = new GameData();
        switch (i)
        {
            // Ball visible
            case 0:
                gameData.areBallsVisible = true;
                gameData.isSoundActive = false;
                gameData.isVibrationActive = false;
                gameData.isBlinkEffectActive = false;
                break;
            
            // Only sound
            case 1:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = true;
                gameData.isVibrationActive = false;
                gameData.isBlinkEffectActive = false;
                break;
            
            // Only vibration
            case 2:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = false;
                gameData.isVibrationActive = true;
                gameData.isBlinkEffectActive = false;
                break;
            
            // Only blink effect
            case 3:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = false;
                gameData.isVibrationActive = false;
                gameData.isBlinkEffectActive = true;
                break;
            
            // Sound, vibration
            case 4:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = true;
                gameData.isVibrationActive = true;
                gameData.isBlinkEffectActive = false;
                break;
            
            // Sound, blink effect
            case 5:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = true;
                gameData.isVibrationActive = false;
                gameData.isBlinkEffectActive = true;
                break;
            
            // Vibration, blink effect
            case 6:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = false;
                gameData.isVibrationActive = true;
                gameData.isBlinkEffectActive = true;
                break;
            
            // All regular effects
            case 7:
                gameData.areBallsVisible = false;
                gameData.isSoundActive = true;
                gameData.isVibrationActive = true;
                gameData.isBlinkEffectActive = true;
                break;
        }

        return gameData;
    }

    UserData GetSpecificUser(AllUsers allUsers, int i)
    {
        return allUsers.userDatas[i];
    }


    AllUsers ReadAllUsersJson(out bool fileFound)
    {
        var filePath = Application.persistentDataPath + "/savedData.txt";
        Debug.Log($"File path: {filePath}");

        if (!UnityEngine.Windows.File.Exists(filePath))
        {
            fileFound = false;
            return new AllUsers();
        }

        fileFound = true;
        
        // Some users already exist
        byte[] bytes = File.ReadAllBytes(filePath);

        string allUsersJson = Encoding.ASCII.GetString(bytes);
        AllUsers allUsers = JsonUtility.FromJson<AllUsers>(allUsersJson);
        return allUsers;
    }
    
    public void StartUpdatingGraph()
    {

       
        //StartCoroutine(CreateDataSet());
    }

    IEnumerator CreateDataSet()
    {
        //  yield return new WaitForSeconds(3.0f);
        while (true)
        {
            GenerateRandomData();

            yield return new WaitForSeconds(2.0f);
        }
    }

    void GenerateRandomData()
    {
        int dataSetIndex = UnityEngine.Random.Range(0, exampleDataSet.Count);
        int xyValueIndex = UnityEngine.Random.Range(0, exampleDataSet[dataSetIndex].ListOfBars.Count);
        exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue = UnityEngine.Random.Range(barGraphGenerator.yMinValue, barGraphGenerator.yMaxValue);
        barGraphGenerator.AddNewDataSet(dataSetIndex, xyValueIndex, exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue);
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
            return "Sound, Vibration, blink effect";
        
        return "Unknown type";

    }
    
}



