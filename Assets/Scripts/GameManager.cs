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
            LoadCurrentUserData();
        }
        
    }
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString(userData.id,json);
        PlayerPrefs.SetString("CurrentUserID",userData.id);
        PlayerPrefs.Save();
        Debug.Log("UserData Saved:" + json);
    }
    public void LoadUserData(string id)
    {
        if (PlayerPrefs.HasKey(id))
        {
            string json = PlayerPrefs.GetString(id);
            userData = JsonUtility.FromJson<UserData>(json);
            PlayerPrefs.SetString("CurrentUserID",id);
            Debug.Log("UserData loaded: "+json);
        }
        else
        {
            Debug.Log("User not found: "+id);
        }
    }
    public void LoadCurrentUserData()
    {
        if (PlayerPrefs.HasKey("CurrentUserID"))
        {
            string id = PlayerPrefs.GetString("CurrentUserID");
            LoadUserData(id);
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
