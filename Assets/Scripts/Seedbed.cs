using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedbed : MonoBehaviour
{
   ToolBarController toolBarController;
    public static int STEP_EMPTY = 0;
    public static int STEP_GROWS = 1;
    public static int STEP_READY = 2;
    
    int dropCount;
    float spread = 2f;

    private SpriteRenderer seedbedSpriteRenderer;
    private SpriteRenderer seedSpriteRenderer;
    private SpriteRenderer readyPlantSpriteRenderer;

    private ItemContainer itemContainer;
    private GameObject player;
    private bool readyForAction;
    _Item seed;
    private string nameProdact;
    private int step = 0;
    const float TTL = 500f;
    float ttl = TTL;
    private void Start()
    {
         itemContainer = GameManager.instance.itemContainer;
         player = GameManager.instance.Player;
         toolBarController = player.GetComponent<ToolBarController>();
         seedbedSpriteRenderer = GetComponent<SpriteRenderer>();
         seedSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
         readyPlantSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[2];
         
    }


    private void Update()
    { if (step == STEP_EMPTY)
        {
            ttl -= Time.fixedDeltaTime;
            if (ttl < 0)
            {
                Destroy(gameObject);
            }
        } else if (step != STEP_EMPTY)
        {
            ttl = TTL;
        }
    }

    private void OnMouseDown()
    {

        seed =  toolBarController.GetItem;
        
        if (readyForAction)
        {
            if (step == STEP_EMPTY && seed != null)
            {
                if (seed.TYPESEED != null && Vector3.Distance(this.transform.position, player.transform.position) < 1.7f)
                {
                    step = STEP_GROWS;
                    readyForAction = false;
                    seedSpriteRenderer.sprite = seed.icon;
                    bool complete = seed.TYPESEED.OnApplyToItemContainer(seed, itemContainer);
                    nameProdact = seed.name;
                    StartCoroutine(grow());
                }
            }

            else if (step == STEP_READY && Vector3.Distance(this.transform.position, player.transform.position) < 1.7f)
            {
                readyPlantSpriteRenderer.sprite = Resources.Load<Sprite>("empty");
                 
               dropCount = Random.Range(2,5);
               step = STEP_EMPTY;
                while (dropCount > 0)
                {
                dropCount--;
                 Vector3 position = transform.position;
                  position.x += spread * UnityEngine.Random.value - spread / 2;
                 position.y += spread * UnityEngine.Random.value - spread / 2;
                  GameObject go = Instantiate(Resources.Load<GameObject>(nameProdact), position, Quaternion.identity);
                     go.transform.position = position;
               }
            }
        }
    }
       
    private IEnumerator grow()
    {
        yield return new WaitForSeconds(seed.timeToGrow);
        seedSpriteRenderer.sprite = Resources.Load<Sprite>("empty");
        readyPlantSpriteRenderer.sprite = seed.plant;

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