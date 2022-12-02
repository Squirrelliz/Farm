using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    [SerializeField] GameObject inventaryPanel;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject storePanelToSell;
    [SerializeField] ItemContainer playerInventory;
    Store store;
    ItemStorePanel itemStorePanel;
    Character character;

    
    private void Awake()
    {
        
        itemStorePanel = storePanel.GetComponent<ItemStorePanel>();
        character = GetComponent<Character>();
       
    }

    internal void BuyItem(int id)
    {
        _Item itemToBuy = store.storeContent.slots[id].item;
        int totalPriceItemToBuy = itemToBuy.price;
        if(character.CheckMoney(totalPriceItemToBuy) == true)
        {
            character.Decrease(totalPriceItemToBuy);
            playerInventory.Add(itemToBuy);
        }
    }

    public void BeginTrading(Store store)
    {
        this.store = store;
        
        itemStorePanel.Clear();
        itemStorePanel.SetInventory(store.storeContent);
        inventaryPanel.SetActive(!inventaryPanel.activeInHierarchy);
        toolbarPanel.SetActive(!inventaryPanel.activeInHierarchy);
        storePanel.SetActive(inventaryPanel.activeInHierarchy);
    }

    public void SellItem()
    {
        if (GameManager.instance.dragAndDropController.CheckForSale() == true)
        {
            ItemSlot itemSlotToSell = GameManager.instance.dragAndDropController.itemSlot;
            int moneyGain = itemSlotToSell.item.price;
            character.AddMoney(moneyGain);
            itemSlotToSell.count--;
            if (itemSlotToSell.count == 0) { 
            itemSlotToSell.Clear();
           }
            GameManager.instance.dragAndDropController.UpdateIcon();
        }
    }

}
