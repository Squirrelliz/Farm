using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsPlayerController : MonoBehaviour
{
    PlayerMovment character;
    Rigidbody2D rbOfPlayer;
    [SerializeField] float offsetDistanse = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    private void Awake()
    {
        character = GetComponent<PlayerMovment>();
        rbOfPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rbOfPlayer.position + character.lastMovement * offsetDistanse;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
