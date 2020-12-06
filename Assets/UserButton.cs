using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserButton : MonoBehaviour
{
    public string userName;
    public int userId;
    
    public void Init(string _userName, int _userId)
    {
        userName = _userName;
        userId = _userId;

        GetComponentInChildren<TMP_Text>().text = _userName;
    }

    public void ClickedOn()
    {
        FindObjectOfType<StatsManager>().ButtonClickedOn(userId);
    }
    
}
