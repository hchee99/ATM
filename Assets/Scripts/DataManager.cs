//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public class DataManager : MonoBehaviour
//{
//    public static DataManager Instance;

//    private string filePath;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//    }
//    private void Start()
//    {
//        filePath = Path.Combine(Application.persistentDataPath, "userData.json");
//    }
//    public void SaveUserData(UserData userData)
//    {
//        string json = JsonUtility.ToJson(userData,true);
//        File.WriteAllText(filePath, json);
//    }
//    public UserData LoadUserData()
//    {
//        if (File.Exists(filePath))
//        {
//            string json = File.ReadAllText(filePath);
//            UserData loadedData = JsonUtility.FromJson<UserData>(json);
//            return loadedData;
//        }
//        else
//        {
//            return null;
//        }
//    }
//}
