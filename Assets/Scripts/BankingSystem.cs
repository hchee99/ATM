using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class BankingSystem : MonoBehaviour
{
    public static BankingSystem Instance;

    public GameObject PopupError;
    public GameObject LowMoneyError;
    public GameObject NoDataError;
    public GameObject NoInputError;

    public TMP_InputField customInputField;
    public TMP_InputField sendNameField;
    public TMP_InputField sendMoneyField;

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
            LowMoneyError.SetActive(true);
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
            LowMoneyError.SetActive(true);
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
        LowMoneyError.SetActive(false);
        NoInputError.SetActive(false);
        NoDataError.SetActive(false);
    }
    public void SendMoney(int money)
    {
        ClosePopup();

        if (string.IsNullOrEmpty(sendMoneyField.text) || string.IsNullOrEmpty(sendNameField.text))
        {
            PopupError.SetActive(true);
            NoInputError.SetActive(true);
            return;
        }
        
        if (!int.TryParse(sendMoneyField.text, out money))
        {
            PopupError.SetActive(true);
            NoInputError.SetActive(true);
            return;
        }

        UserData sender = GameManager.Instance.userData;
        string receiverId = sendNameField.text;

        if (sender.id == receiverId)
        {
            PopupError.SetActive(true);
            NoDataError.SetActive(true);
        }
        if (sender.cash < money)
        {
            PopupError.SetActive(true);
            LowMoneyError.SetActive(true);
            Debug.Log("잔액 부족");
            return;
        }
        if (!PlayerPrefs.HasKey(receiverId))
        {
            PopupError.SetActive(true);
            NoDataError.SetActive(true);
            Debug.Log("존재하지 않는 사용자");
            return;
        }

        sender.cash -= money;

        string receiverJson = PlayerPrefs.GetString(receiverId);
        UserData receiver = JsonUtility.FromJson<UserData>(receiverJson);
        receiver.cash += money;

        string updatedReceiverJson = JsonUtility.ToJson(receiver);
        PlayerPrefs.SetString(receiver.id, updatedReceiverJson); // 받는 사람 저장
        GameManager.Instance.SaveUserData(); // 보내는 사람 저장

        UIManager.Instance.Refresh();
    }
}
