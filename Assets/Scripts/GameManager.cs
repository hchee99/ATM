using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    private string userName = "Name";
    private int cash = 100000;
    private int balance = 50000;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        userData = new UserData(userName, cash, balance);
    }
}
