using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanelToSell : ItemPanel
{
    [SerializeField] Trading trading;
    public override void OnClick(int id)
    {
        SellItem();
        Show();
    }

  public void  SellItem()
    {
        trading.SellItem();
    }


}
