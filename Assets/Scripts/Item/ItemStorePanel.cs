using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorePanel : ItemPanel
{
    [SerializeField] Trading trading;

    public override void Show()
    {
        if (inventory == null) { return; }
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].SetShop(inventory.slots[i]);
            }
        }
    }
    public override void OnClick(int id)
    {
        if (GameManager.instance.dragAndDropController.itemSlot.item == null)
        {
            BuyItem(id);
        }
      //  else
       // {
       //     SellItem();
       // }
        
        Show();
    }



    

    private void BuyItem(int id)
    {
        trading.BuyItem(id);
    }

    //public void SellItem()
   // {
  //      trading.SellItem();
  //  }

    
}


