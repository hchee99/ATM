using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject ATM;
    public GameObject sendMoneyPanel;


    public void ShowDepositPanel()
    {
        depositPanel.SetActive(true);
        withdrawPanel.SetActive(false);
        ATM.SetActive(false);
    }
    public void ShowWithDrawPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(true);
        ATM.SetActive(false);
    }
    public void ShowSendMoneyPanel()
    {
        sendMoneyPanel.SetActive(true);
        ATM .SetActive(false);
    }
    public void ClosePanel()
    {
        sendMoneyPanel.SetActive(false);
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        ATM.SetActive(true);
    }
}
