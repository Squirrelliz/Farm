using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class StoreButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text textName;
    [SerializeField] Text price;
    [SerializeField] Image bitcoin;
    [SerializeField] ItemContainer shop;
    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        bitcoin.gameObject.SetActive(true);
        price.gameObject.SetActive(true);
        price.text = slot.item.price.ToString();
        textName.text = slot.item.name;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        ItemStorePanel itemPanel = transform.parent.GetComponent<ItemStorePanel>();
        itemPanel.OnClick(myIndex);

    }
}
