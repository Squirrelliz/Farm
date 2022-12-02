using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply() is not implemented");
        return true;
    }

    public virtual bool OnApplyToTilemap(Vector3Int gridPosition, TilemapReadController tilemapReadController)
    {
        Debug.LogWarning("OnApplyToTilemap() is not implemented");
        return true;
    }

    public virtual bool OnApplyToItemContainer(_Item seed, ItemContainer itemContainer)
    {
        Debug.LogWarning("OnApplyToItemContainer() is not implemented");
        return true;
    }
}
