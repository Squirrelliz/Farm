using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] Image highlight;
    [SerializeField] Image bitcoin;
    [SerializeField] Text price;
    [SerializeField] Text name;

    int myIndex;

    ItemPanel itemPanel;

   public void SetItemPanel(ItemPanel source)
    {
        itemPanel = source;
    }
    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        
            if (slot.item.stackable)
            {
                text.gameObject.SetActive(true);
                text.text = slot.count.ToString();
            }
            else
            {
                text.gameObject.SetActive(false);
            }
        
        
           
        
        
    }

    public void SetShop(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        bitcoin.gameObject.SetActive(true);
        price.gameObject.SetActive(true);
        price.text = slot.item.price.ToString();
        name.gameObject.SetActive(true);
        name.text = slot.item.name;
        text.gameObject.SetActive(false);
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.text = null;
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ItemContainer inventory = GameManager.instance.itemContainer;
        //GameManager.instance.dragAndDropController.OnClick(inventory.slots[myIndex]);
        // transform.parent.GetComponent<InventoryPanel>().Show();

        //ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(myIndex);
    }

    public void Highlight(bool b)
    {
        highlight.gameObject.SetActive(b);
    }
}
