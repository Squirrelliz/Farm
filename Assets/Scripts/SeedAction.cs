using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tool Action/Seed")]
public class SeedAction : ToolAction
{
   public override bool OnApplyToItemContainer(_Item seed,ItemContainer itemContainer)
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
        {
            if (itemContainer.slots[i].item == seed)
            {
                if (itemContainer.slots[i].count > 1)
                {
                    itemContainer.slots[i].count -= 1;
                }
                else
                {
                    itemContainer.slots[i].Clear();
                }
            }
        }
        return true;
    }
}
