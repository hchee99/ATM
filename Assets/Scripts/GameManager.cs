using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    private string userName = "Name";
    private string id = "ID";
    private string password = "Password";
    private int cash = 100000;
    private int balance = 50000;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadUserData();
        }
        
    }
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString("UserData",json);
        PlayerPrefs.Save();
        Debug.Log("UserData Saved:" + json);
    }
    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("UserData"))
        {
            string json = PlayerPrefs.GetString("UserData");
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("UserData loaded: "+json);
        }
        else
        {
            userData = new UserData(userName, id, password, cash, balance);
            SaveUserData();
            Debug.Log("saved");
        }
    }
    private void Start()
    {
        //UserData loadedData = DataManager.Instance.LoadUserData();
        //if (loadedData != null)
        //{
        //    userData = loadedData;
        //}
    }
}
