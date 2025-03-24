using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class BankingSystem : MonoBehaviour
{
    public static BankingSystem Instance;

    public GameObject PopupError;

    public TMP_InputField customInputField;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void Deposit(int money)
    {
        if (GameManager.Instance.userData.balance >= money)
        {
            GameManager.Instance.userData.cash += money;
            GameManager.Instance.userData.balance -= money;
            UIManager.Instance.Refresh();
            GameManager.Instance.SaveUserData();
            PopupError.SetActive(false);
        }
        else
        {
            PopupError.SetActive(true);
        }
    }
    public void CustomDeposit(int money)
    {
        if (int.TryParse(customInputField.text, out money))
        {
            BankingSystem.Instance.Deposit(money);
            GameManager.Instance.SaveUserData();
        }
    }
    public void Withdraw(int money)
    {
        if (GameManager.Instance.userData.cash >= money)
        {
            GameManager.Instance.userData.cash -= money;
            GameManager.Instance.userData.balance += money;
            UIManager.Instance.Refresh();
            GameManager.Instance.SaveUserData();
            PopupError.SetActive(false);
        }
        else
        {
            PopupError.SetActive(true);
        }
    }
    public void CustomWithdraw(int money)
    {
        if (int.TryParse(customInputField.text, out money))
        {
            BankingSystem.Instance.Withdraw(money);
            GameManager.Instance.SaveUserData();
        }
    }
    public void ClosePopup()
    {
        PopupError.SetActive(false);
    }
}
