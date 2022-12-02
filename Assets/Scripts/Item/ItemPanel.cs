using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;
    private void Start()
    {
        Init();
     
    }

    public void Init()
    {
         SetSoursePanel();
        SetIndex();
        Show();
       
    }

    

    
    private void SetSoursePanel()
    {
        for(int i=0; i < buttons.Count; i++)
        {
            buttons[i].SetItemPanel(this);
        }
    }

    private void Update()
    {
        Show();
    }
    private void OnEnable()
    {
        Show();
    }
    private void SetIndex()
    {
        for (int i = 0;  i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }
    public virtual void Show()
    {
        if(inventory == null) { return; }
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

 

    public virtual void OnClick(int id)
    {

    }

    public void Clear()
    {
        for (int i = 0;  i < buttons.Count; i++)
        {
            buttons[i].Clean();
        }
    }
    public void SetInventory(ItemContainer newInventory)
    {
        inventory = newInventory;
    }
}
