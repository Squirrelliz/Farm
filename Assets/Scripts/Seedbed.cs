using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedbed : MonoBehaviour
{
 
    public static int STEP_EMPTY = 0;
    public static int STEP_GROWS = 1;
    public static int STEP_READY = 2;
 


    private SpriteRenderer seedbedSpriteRenderer;
    private SpriteRenderer seedSpriteRenderer;
    private SpriteRenderer readyPlantSpriteRenderer;

    private GameObject player;
    private bool readyForAction;
    private Item seedbed;
    private int step = 0;
    private void Start()
    {
         seedbedSpriteRenderer = GetComponent<SpriteRenderer>();
         seedSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
         readyPlantSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[2];

        player = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        
    }

    private void OnMouseDown()
    {

        Item item = new Item("seedPotato", "Plants/seedPotato", "Plants/readyPotato", Item.TYPESEED, 1, 10, 1, 10f);

        if (readyForAction)
        {
            if (step == STEP_EMPTY)
            {
                if (item.type == Item.TYPESEED && Vector3.Distance(this.transform.position, player.transform.position) < 1.7f)
                {
                    step = STEP_GROWS;
                    readyForAction = false;
                    seedbed = item;
                    seedSpriteRenderer.sprite = Resources.Load<Sprite>("Plants/seedPotato");
                    StartCoroutine(grow());
                }
            }

            else if (step == STEP_READY && Vector3.Distance(this.transform.position, player.transform.position) < 1.7f)
            {
                readyPlantSpriteRenderer.sprite = Resources.Load<Sprite>("empty");
                //seedbedSpriteRenderer.sprite = Resources.Load<Sprite>("Seedbed/seedbedDirt");
                step = STEP_EMPTY;

            }
        }
    }
       
    private IEnumerator grow()
    {
        yield return new WaitForSeconds(seedbed.timeToGrow);
        seedSpriteRenderer.sprite = Resources.Load<Sprite>("empty");
        readyPlantSpriteRenderer.sprite = Resources.Load<Sprite>(seedbed.imgUrl2);

        step = STEP_READY;
    }

    private void FixedUpdate()
    {
        if (step != STEP_GROWS)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < 1.7f )
            {
                readyForAction = true;
                seedbedSpriteRenderer.sprite = Resources.Load<Sprite>("Seedbed/seedbedSelected");
            }
            else
            {
                seedbedSpriteRenderer.sprite = Resources.Load<Sprite>("Seedbed/seedbed");
            }

        }
        else
        {
            seedbedSpriteRenderer.sprite = Resources.Load<Sprite>("Seedbed/seedbed");
        }
    }


}