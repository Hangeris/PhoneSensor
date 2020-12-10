using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    AllUsers allUsers;
    
    public GameObject barGraphGO;
    public GameObject userSelectionPanelGO;

    public Transform userSelectionPanelParent;
    public GameObject userSelectionPrefab;

    void Start()
    {
        barGraphGO?.SetActive(false);
        userSelectionPanelGO?.SetActive(true);
        
        bool fileFound;
        allUsers = ReadAllUsersJson(out fileFound);
        if (!fileFound)
        {
            Debug.Log("File was not found");
            return;
        }

        for (int i = 0; i < allUsers.userDatas.Count; i++)
        {
            var buttonScr = Instantiate(userSelectionPrefab, userSelectionPanelParent).GetComponent<UserButton>();
            buttonScr.Init(allUsers.userDatas[i].name, i);
        }
        
        //var specificUser = GetSpecificUser(allUsers, 0);
        
    }
    
    
    AllUsers ReadAllUsersJson(out bool fileFound)
    {
        var filePath = Application.persistentDataPath + "/savedData.txt";
        Debug.Log($"File path: {filePath}");

        if (!File.Exists(filePath))
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


    public void ButtonClickedOn(int userId)
    {        
        barGraphGO?.SetActive(true);
        userSelectionPanelGO?.SetActive(false);

        FindObjectOfType<BarGraphExample>().ShowStatsFromGivenPlayer(allUsers, userId);
    }
}
