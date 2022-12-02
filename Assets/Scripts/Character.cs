using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int money;
    [SerializeField] TMPro.TextMeshProUGUI textMoney;

    private void Start()
    {
        money = 100;
        UpdateText();
    }
    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        textMoney.text = money.ToString();
    }

    public void AddMoney(int moneyAdd)
    {
        money += moneyAdd;
        UpdateText();
    }

    internal bool CheckMoney(int totalPriceItemToBuy)
    {
        return money >= totalPriceItemToBuy;
    }

    internal void Decrease(int totalPrice)
    {
        money -= totalPrice;
    }
}
