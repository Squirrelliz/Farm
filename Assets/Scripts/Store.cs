using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Interactable
{
    public ItemContainer storeContent;
   public GameObject storePanel;
    public override void Interact(Character character)
    {
        Trading trading = character.GetComponent<Trading>();
        if (trading == null)
        {
            return;
        }

        trading.BeginTrading(this);
    }
}
