using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
   Transform player;
   [SerializeField] float speed = 6f;
   [SerializeField] float pickUpDistance = 2f;
   [SerializeField] float ttl = 10f;

    private void Awake()
    {
        player = GameManager.instance.Player.transform;
    }

    public void Set(_Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

    public _Item item;
    public int count = 1;
    private void Update()
    {
        ttl -= Time.fixedDeltaTime;
        if (ttl < 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        if (distance < 0.1f)
        {
            if (GameManager.instance.itemContainer!=null)
            {
                GameManager.instance.itemContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("No inventory container attached to the Game Manager");
            }
            Destroy(gameObject);
        }
    }
}
