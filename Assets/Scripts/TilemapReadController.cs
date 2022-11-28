using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapReadController : MonoBehaviour
{
 
    [SerializeField] Tilemap ground;
    [SerializeField] GameObject seedbed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         
            GetTileBase(Input.mousePosition);
            
        }
    }


    public TileBase GetTileBase(Vector2 mousePosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3Int gridPosition = ground.WorldToCell(worldPosition);

        TileBase tile = ground.GetTile(gridPosition);

        Vector2 mousePos = new Vector2(gridPosition.x,gridPosition.y);

        Collider2D[] collidersInCircle = Physics2D.OverlapCircleAll(mousePos, 0.4f);

        if (tile.name == "plowable" && collidersInCircle.Length == 1)
        {
            
                Instantiate(seedbed, gridPosition, Quaternion.identity);
            
        }
      
        return null;
    }
}
