using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsPlayerController : MonoBehaviour
{
    PlayerMovment character;
    Rigidbody2D rbOfPlayer;
    Animator playerAnimator;
    ToolBarController toolBarController;
    [SerializeField] float offsetDistanse = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] TilemapReadController tilemapReadController;
    [SerializeField] float maxDistance = 3f;
    Vector3Int selectedTilePosition;
    bool selectable;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        character = GetComponent<PlayerMovment>();
        rbOfPlayer = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTile();
            CanSelectCheck();
            UseToolGrid();
            if (UseToolWorld() == true)
            {
                return;
            }
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tilemapReadController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 playerPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(playerPosition, cameraPosition) < maxDistance;
    }
    private bool UseToolWorld()
    {
        Vector2 position = rbOfPlayer.position + character.lastMovement * offsetDistanse;

        _Item item = toolBarController.GetItem;

        if (item == null) { return false;}

        if (item.TYPEAXE == null) { return false;}

     
       bool complete = item.TYPEAXE.OnApply(position);
        
       return complete;
    
    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
            _Item item = toolBarController.GetItem;
            
            if(item == null) { return ; }
           
            if(item.TYPEHOE == null) { return ; }

            bool complete = item.TYPEHOE.OnApplyToTilemap(selectedTilePosition, tilemapReadController);
            //TileBase tileBase = tilemapReadController.GetTileBase(selectedTilePosition);
            //TileData tileData = tilemapReadController.GetTileData(tileBase);
            // if (tileData != plowableTiles) { return; }
            //cropManager.Plow(selectedTilePosition);
        }

    }

    private void UseToolSeed()
    {

    }
}

