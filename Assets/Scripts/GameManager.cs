using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;

    }
    public ItemContainer itemContainer;
    public GameObject Player;
    public ItemDragAndDropController dragAndDropController;
    public CropsManager cropsManager;
    public TilemapReadController tilemapReadController;
    public Character character;
    public ItemContainer Shop;
}
