using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteracteController : MonoBehaviour
{
    PlayerMovment playerMovement;
    Rigidbody2D rbOfPlayer;
    [SerializeField] float offsetDistanse = 10f;
    [SerializeField] float sizeOfInteractableArea = 4f;
    Character character;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovment>();
        rbOfPlayer = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) {

            Interact();
        }
    }
    public  void Interact()
    {
        Vector2 position = rbOfPlayer.position + playerMovement.lastMovement * offsetDistanse;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }

       
    }
}
