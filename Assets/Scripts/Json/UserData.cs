using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UserData
{
    public string name;
    public Gender gender;
    public List<GameData> gameDatas;

    public UserData(string _name, Gender _gender)
    {
        name = _name;
        gender = _gender;
        gameDatas = new List<GameData>();
    }

    public void AddGameData(GameData gameData)
    {
        gameDatas.Add(gameData);
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        return ((UserData) obj).name == name;
    }

    public bool ContainsGameData(GameData givenGameData, out GameData gameData)
    {
        gameData = givenGameData;
        
        if (gameDatas == null || gameDatas.Count == 0)
            return false;
        
        for (int i = 0; i < gameDatas.Count; i++)
        {
            if (gameDatas[i].Equals(givenGameData))
            {
                gameData = gameDatas[i];
                return true;
            }
        }

        return false;
    }

}
