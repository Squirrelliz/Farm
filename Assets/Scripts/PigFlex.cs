using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigFlex : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip audioClip;
    Vector3 position;
    float time = 5f;
    private void Start()
    {
         position = transform.position;
    }

    private void Update()
    {
       
        if (Vector3.Distance(player.transform.position, position) < 10f && inventory.activeInHierarchy==false)
        {
            AudioManager.instance.Play(audioClip);
            animator.SetTrigger("Player");
           

        }
    }
    private IEnumerator stopFlex()
    {

        yield return new WaitForSecondsRealtime(time);
        animator.ResetTrigger("Player");

    }
}
