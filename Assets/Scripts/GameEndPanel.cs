using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using File = UnityEngine.Windows.File;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] Transform gameEndPanel;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_Dropdown genderDropdown;

    int time = 0;
    bool isCorrect = false;

    string filePath;
    
    void Awake()
    {
        filePath = Application.persistentDataPath + "/savedData.txt";
        gameEndPanel.gameObject.SetActive(false);
    }


    public void Show(float time, bool isCorrect)
    {
        this.time = (int)time;
        this.isCorrect = isCorrect;
        
        Time.timeScale = 0;
        gameEndPanel.gameObject.SetActive(true);
    }

    public void BTN_Submit()
    {
        string userName = nameInputField.text;
        Gender gender = (Gender)genderDropdown.value;
        
        bool areBallsVisible = UIController.AreBallsVisible;
        bool isVibrationActive = UIController.IsVibrationActive;
        bool isBlinkEffectActive = UIController.IsBlinkEffectActive;
        bool isSoundActive = UIController.IsSoundActive;

        if (DoesSaveDataFileExist())
        {
            // Some users already exist
            byte[] bytes = File.ReadAllBytes(filePath);

            string allUsersJson = Encoding.ASCII.GetString(bytes);
            AllUsers allUsers = JsonUtility.FromJson<AllUsers>(allUsersJson);
            
            UserData userData = new UserData(userName, gender);
            GameData gameData = new GameData(areBallsVisible, isVibrationActive, isBlinkEffectActive, isSoundActive);
            SpecificGameData specificGameData = new SpecificGameData(time, isCorrect);

            if (allUsers.ContainsUserData(userData, out userData))
            {
                // The user exists
                
                if (userData.ContainsGameData(gameData, out gameData))
                {
                    // GameData exists
                    gameData.AddSpecificGame(specificGameData);
                    
                }
                else
                {
                    // GameData does not exist
                    gameData.AddSpecificGame(specificGameData);
                    userData.AddGameData(gameData);
                }
            }
            else
            {
                // The user does not exist
                gameData.AddSpecificGame(specificGameData);
                userData.AddGameData(gameData);
                allUsers.AddUser(userData);
            }
            
            // Write new json to file
            allUsersJson = JsonUtility.ToJson(allUsers);
            bytes = Encoding.ASCII.GetBytes(allUsersJson);
            File.WriteAllBytes(filePath, bytes);
        }
        else
        {
            // Create new file with the first user
            
            var userData = GenerateAndPopulateNewUserData(
                userName, gender, 
                areBallsVisible, isVibrationActive, isBlinkEffectActive, isSoundActive);

            AllUsers allUsers = new AllUsers();
            allUsers.AddUser(userData);
            
            string allUsersJson = JsonUtility.ToJson(allUsers);
            Debug.Log(allUsersJson);

            byte[] bytes = Encoding.ASCII.GetBytes(allUsersJson);
            File.WriteAllBytes(filePath, bytes);
        }
      
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    UserData GenerateAndPopulateNewUserData(string userName, Gender gender, bool areBallsVisible, bool isVibrationActive,
        bool isBlinkEffectActive, bool isSoundActive)
    {
        UserData userData = new UserData(userName, gender);
        GameData gameData = new GameData(areBallsVisible, isVibrationActive, isBlinkEffectActive, isSoundActive);
        SpecificGameData specificGameData = new SpecificGameData(time, isCorrect);

        gameData.specificGameDatas.Add(specificGameData);
        userData.gameDatas.Add(gameData);
        return userData;
    }

    bool DoesSaveDataFileExist()
    {
        return File.Exists(filePath);
    }

    // string GetSavedData(string filePath)
    // {
    //     File file = 
    //
    // }
    
}
