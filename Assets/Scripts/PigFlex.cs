using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigFlex : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    Vector3 position;
    float time = 5f;
    private void Start()
    {
         position = transform.position;
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, position) < 4f && inventory.activeInHierarchy==false)
        {
            animator.SetTrigger("Player");
            stopFlex();

        }
    }
    private IEnumerator stopFlex()
    {

        yield return new WaitForSecondsRealtime(time);
        animator.ResetTrigger("Player");

    }
}
