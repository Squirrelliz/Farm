using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tool Action/Gather Resource Node")]
public class GatherResourseNode : ToolAction
{
    Animator player;
    PlayerMovment playerMovement;
    
    [SerializeField] float sizeOfInteractableArea = 1f;
    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                player = GameManager.instance.Player.GetComponent<Animator>();
                playerMovement = GameManager.instance.Player.GetComponent<PlayerMovment>();

                Vector2 v = playerMovement.lastMovement;

                player.SetFloat("Horizontal",v.x);
                player.SetFloat("Vertical", v.y);
                player.SetTrigger("Cut");
                cutTree();

      
                    hit.Hit();

                return true;
            
        }
        }

        return false;
    }

   private IEnumerator cutTree()
    {
        
        yield return new WaitForSecondsRealtime(3f);
        player.ResetTrigger("Cut");

    }
}
