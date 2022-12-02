using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsManager : MonoBehaviour
{
    [SerializeField] GameObject crop;
    Animator player;
    PlayerMovment playerMovement;
    public void Plow(Vector3Int gridPosition)
    {
        Vector2 mousePos = new Vector2(gridPosition.x, gridPosition.y);

        Collider2D[] collidersInCircle = Physics2D.OverlapCircleAll(mousePos, 0.3f);
        if (collidersInCircle.Length == 1)
        {
            player = GameManager.instance.Player.GetComponent<Animator>();
            playerMovement = GameManager.instance.Player.GetComponent<PlayerMovment>();

            Vector2 v = playerMovement.lastMovement;

            player.SetFloat("Horizontal", v.x);
            player.SetFloat("Vertical", v.y);
            player.SetTrigger("Plow");
            plow();
            Instantiate(crop, gridPosition, Quaternion.identity);
        }

    }

    private IEnumerator plow()
    {

        yield return new WaitForSecondsRealtime(3f);
        player.ResetTrigger("Plow");

    }
}
