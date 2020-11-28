using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AllUsers
{
    public List<UserData> userDatas;

    public void AddUser(UserData userData)
    {
        if (userDatas == null)
        {
            userDatas = new List<UserData>();
        }
        
        userDatas.Add(userData);
    }

    public bool ContainsUserData(UserData givenUserData, out UserData containedUserData)
    {
        containedUserData = givenUserData;
        
        if (userDatas == null || userDatas.Count == 0)
            return false;
        
        for (int i = 0; i < userDatas.Count; i++)
        {
            if (userDatas[i].Equals(givenUserData))
            {
                containedUserData = userDatas[i];
                return true;
            }
        }

        return false;
    }

    
}
