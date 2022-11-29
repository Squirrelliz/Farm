using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapReadController : MonoBehaviour
{
 
    [SerializeField] Tilemap ground;
    [SerializeField] List<TileData> tileDatas;
    public CropsManager cropsManager;
    Dictionary<TileBase, TileData> dataFromTiles;
    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(TileData tileData in tileDatas)
        {
            foreach(TileBase tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }


    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 worldPosition;

        if (mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }

        Vector3Int gridPosition = ground.WorldToCell(worldPosition);
        
        return gridPosition;
    }
    public TileBase GetTileBase(Vector3Int gridPosition)
    {
        TileBase tile = ground.GetTile(gridPosition);


        return tile;
    }

    public TileData GetTileData(TileBase tile)
    {
        return dataFromTiles[tile];
    }
}
