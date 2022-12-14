using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragAndDropController : MonoBehaviour
{ 
    public ItemSlot itemSlot;
    [SerializeField] GameObject dragItemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = dragItemIcon.GetComponent<RectTransform>();
        itemIconImage = dragItemIcon.GetComponent<Image>();
    }

    public bool CheckForSale()
    {
        if (itemSlot.item == null) { return false; }
        if(itemSlot.item.canBeSold == false) { return false; }
        return true;
    }
    private void Update()
    {
        if (dragItemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    //this.itemSlot.Clear();
                    UpdateIcon();
                   
                }
            }
        }
    }
    internal void OnClick(ItemSlot itemSlot)
    { //  if(this.itemSlot.item != null && StorePanel.activeInHierarchy == true)
      //  {
      //      itemSlot.count -= 1;
       //     character.AddMoney(itemSlot.item.price);
       //     if (itemSlot.count == 0)
       //     {
       //         itemSlot.Clear();
       //     }
        //}
       // else { 
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
            UpdateIcon();
        }
        else
        {
            _Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
            UpdateIcon();
        }
        //}
    }

   public void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            dragItemIcon.SetActive(false);
        }
        else
        {
            dragItemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
