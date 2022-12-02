using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] GameObject inventaryPanel;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject storePanel;
     private GameObject Player;

    private void Start()
    {
        Player = GameManager.instance.Player;
    }

    private void OnMouseDown()
    {
        if(Vector3.Distance(this.transform.position, Player.transform.position) < 3f)
        {
            inventaryPanel.SetActive(!inventaryPanel.activeInHierarchy);
            toolbarPanel.SetActive(!inventaryPanel.activeInHierarchy);
            storePanel.SetActive(inventaryPanel.activeInHierarchy);
        }
    }


}
