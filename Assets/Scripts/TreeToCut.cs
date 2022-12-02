using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeToCut : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 2f;
    public override void Hit()
    { 
        while (dropCount > 0)
        {
            dropCount--;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop, position, Quaternion.identity);
            go.transform.position = position;
        }
        Destroy(gameObject);
    }


}
