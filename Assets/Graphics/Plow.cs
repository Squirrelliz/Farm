using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Plow : MonoBehaviour
{
    [SerializeField] Tilemap ground;
    [SerializeField] GameObject seedbed;
    [SerializeField] GameObject player;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            CheckTileAndPlow(Input.mousePosition);

        }
    }


    public TileBase CheckTileAndPlow(Vector2 mousePosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3Int gridPosition = ground.WorldToCell(worldPosition);

        TileBase tile = ground.GetTile(gridPosition);

        Vector2 mousePos = new Vector2(gridPosition.x, gridPosition.y);

        Collider2D[] collidersInCircle = Physics2D.OverlapCircleAll(mousePos, 0.4f);

        if (tile.name == "plowable" && collidersInCircle.Length == 1
                                    && Vector3.Distance(gridPosition, player.transform.position) < 2f)
        {

            Instantiate(seedbed, gridPosition, Quaternion.identity);

        }

        return null;
    }
}
