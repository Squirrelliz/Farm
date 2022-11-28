using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemSlot
{
    public _Item item;
    public int count;

    public void Copy(ItemSlot itemSlot)
    {
        item = itemSlot.item;
        count = itemSlot.count;
    }

    public void Set(_Item item, int count)
    {
        this.item = item;
        this.count = count;
    }
    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(_Item item, int count = 1)
    {
        if (item.stackable)
        {
            bool isInInventory = false;
            for (int i = 0; i < slots.Count && isInInventory == false; i++)
            {
                if (slots[i].item == item)
                {
                    slots[i].count += count;
                    isInInventory = true;
                }
            }

            if (isInInventory == false)
            {
                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].item == null)
                    {
                        slots[i].count = count;
                        slots[i].item = item;
                        break;
                    }
                }
            }
        }
        else
        {
            //add non stackable to item container
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot.item != null)
            {
                itemSlot.item = item;
            }
        }
    }
}
