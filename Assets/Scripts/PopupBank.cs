using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject ATM;

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
    public void ClosePanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        ATM.SetActive(true);
    }
}
