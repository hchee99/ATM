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
        GameManager.Instance.userData.id = idField.text;
        GameManager.Instance.userData.userName = nameField.text;
        GameManager.Instance.userData.password = pwField.text;
        GameManager.Instance.SaveUserData();
        signupPanel.SetActive(false);
    }
}
