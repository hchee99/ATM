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

    public void Login()
    {
        var data = GameManager.Instance.userData;
        if (idField.text == data.id && pwField.text == data.password)
        {
            GameManager.Instance.SaveUserData();
            SceneManager.LoadScene("MainScene");
        }
        else
        {

        }
    }
    public void SignUp()
    {
        
    }
}
