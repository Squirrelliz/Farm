using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/Tool Action/ Plow")]
public class PlowTile : ToolAction
{
    [SerializeField]List<TileBase> canPlow;
   
    public override bool OnApplyToTilemap(Vector3Int gridPosition, TilemapReadController tilemapReadController)
    {
        TileBase tile = tilemapReadController.GetTileBase(gridPosition);
        if (!canPlow.Contains(tile))
        {
            return false;

        }



        tilemapReadController.cropsManager.Plow(gridPosition);
        return true;
    }

    
}
