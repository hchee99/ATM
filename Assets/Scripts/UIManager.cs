using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
    
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (GameManager.Instance != null)
        {
            nameText.text = GameManager.Instance.userData.userName;
            cashText.text = GameManager.Instance.userData.cash.ToString();
            balanceText.text = GameManager.Instance.userData.balance.ToString();
        }
    }
}
