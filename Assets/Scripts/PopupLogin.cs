using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField pwField;
    public GameObject loginpanel;
    public GameObject passwordpanel;
    public GameObject signuppanel;

    public void Login()
    {
        string inputId = idField.text;
        string inputPw = pwField.text;
        
        if (PlayerPrefs.HasKey(inputId))
        {
            string json = PlayerPrefs.GetString(inputId);
            UserData loadedData = JsonUtility.FromJson<UserData>(json);

            if (loadedData.password == inputPw)
            {
                GameManager.Instance.userData = loadedData;
                GameManager.Instance.SaveUserData();
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }
    public void SignUp()
    {
        signuppanel.SetActive(true);
    }
}
