using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public string id;
    public string password;
    public int cash;
    public int balance;

    public UserData(string userName, string id, string password, int cash, int balance)
    {
        this.userName = userName;
        this.id = id;
        this.password = password;
        this.cash = cash;
        this.balance = balance;
    }

}

