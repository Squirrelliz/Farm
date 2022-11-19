using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine;

public class SpawnSeedbed : MonoBehaviour
{
   public GameObject seedbed;
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        
           
                Instantiate(seedbed, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0),Quaternion.identity);
            

        }
    }
}
