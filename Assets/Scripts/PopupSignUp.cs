using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopupSignUp : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField nameField;
    public TMP_InputField pwField;
    public TMP_InputField pwConfirmField;

    public GameObject errorPanel;
    public GameObject signupPanel;

    public void SignUpError()
    {
        string newId = idField.text;

        if (pwField.text != pwConfirmField.text || idField.text == GameManager.Instance.userData.id)
        {
            errorPanel.SetActive(true);
        }
        else
        {
            SaveID();
        }
    }

    public void Cancle()
    {
        signupPanel.SetActive(false);
    }

    public void OK()
    {
        errorPanel.SetActive(false);
    }

    public void SaveID()
    {
        UserData newUser = new UserData(
            nameField.text,
            idField.text,
            pwField.text,
            100000,
            50000
        );

        string json = JsonUtility.ToJson( newUser);
        PlayerPrefs.SetString(newUser.id, json);
        PlayerPrefs.SetString("CurrentUserId",newUser.id);
        PlayerPrefs.Save();

        GameManager.Instance.userData = newUser;
        signupPanel.SetActive(false);
    }
}
