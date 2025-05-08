using UnityEngine;
using UnityEngine.UI;

public class HandHolderManage : MonoBehaviour
{

    public Transform handHolder;
    public GameObject[] objectsHeld;
    public GameObject currentItemHeld;
    private int currentIndex = -1;
    public Image[] inventorySlotImage; //create array with all the images of the items in inventory
    private bool[] hasItem; //keep track of if I have it (haven't dropped it before)


    void Start()
    {
        hasItem = new bool[objectsHeld.Length];
        
        for (int i = 0; i < hasItem.Length; i++) //for every item in the objects we can hold...
        {
            hasItem[i] = true; //start with everything
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DropCurrentItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipItem(0); //if 1 is clicked, first object
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipItem(1); //if 2 is clicked, second object in inventory
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipItem(2); //goes on
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) EquipItem(4);
    }

    void EquipItem(int index)
    {

        //DEBUG: problems with clicking same num twice, game crashes
        if (currentIndex == index)
        {
            Debug.Log("Item there in index..." + index + ", skip it.");
            return;
        }

        if (!hasItem[index])
        {
            Debug.Log("You dropped this item already.");
            return;
        }


        if (index < 0 || index >= objectsHeld.Length) return; //if index is less than 0, then get the length of the prefab items
        
        //if the player is holding something, then destory it
        if (currentItemHeld != null)
        {
            Destroy(currentItemHeld);
        }

        //spawn the next item in the prefab at that loc
        currentItemHeld = Instantiate(objectsHeld[index], handHolder);
        currentItemHeld.transform.localPosition = Vector3.zero;

        currentIndex = index;
    }

    void DropCurrentItem()
    {
        if (currentItemHeld == null)
        {
            Debug.Log("Holding nothing at the moment");
            return;
        }

        GameObject dropped = Instantiate(objectsHeld[currentIndex]);
        dropped.transform.localScale *= 15f;
        Destroy(currentItemHeld);

        //store the index of the dropped item (to keep track in case they pick it back up)
        ItemDrop itemDrop = dropped.AddComponent<ItemDrop>();
        itemDrop.itemIndex = currentIndex; // Set the itemIndex on the dropped item


        //on the object that has been isntantiated on the ground, i can still shoot with it when left clicking
        disableScript(dropped); //this script disables the script on the object/weapon created so it does't make noise/function anymore

        //it's placed in front of player AND it's on the terrain ground
        Vector3 dropDirection = Camera.main.transform.forward;
        Vector3 dropPos = handHolder.position + dropDirection * 15f;
        dropPos.y = Terrain.activeTerrain.SampleHeight(dropPos) + Terrain.activeTerrain.transform.position.y;
        dropped.transform.position = dropPos;

        if (currentIndex == 1 || currentIndex == 2)
        {
            dropped.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }

        if(currentIndex < inventorySlotImage.Length)
        {
            inventorySlotImage[currentIndex].enabled = false; //hide the image
        }

        //makes sure to keep track of what has been dropped, so it can't be held again - but only for the axe, knife, and gun
        if (currentIndex <= 2)
        {
            hasItem[currentIndex] = false;
        }
        
        currentItemHeld = null; //i'm now back to holding nothing

    }

    void disableScript(GameObject weapon)
    {
        //if the gun is active, disable it/disable the scripts - same with all the other ones
        var gun = weapon.GetComponent<shooting>();
        if (gun != null)
        {
            gun.enabled = false;
        }

        var knife = weapon.GetComponent<KnifeHit>();
        if (knife != null)
        {
            knife.enabled = false;
        }  

        var axe = weapon.GetComponent<AxeHit>();
        if (axe != null)
        {
            axe.enabled = false;
        }  
    }

    void OnTriggerEnter(Collider weapon)
    {
        if(weapon.CompareTag("pick up"))
        {
            PickupItem(weapon.gameObject);
        }
    }


    public void PickupItem(GameObject item)
    {
        ItemDrop itemDrop = item.GetComponent<ItemDrop>(); //accessing ItemDrop components (like itemIndex)

        if(itemDrop != null)
        {
            int itemIndex = itemDrop.itemIndex; //grab the index of the item that was dropped
            
            //if the item is NOT in our inventory/was dropped...
            if (!hasItem[itemIndex]) 
            {
                //activate it's place in the inventory + show the photo again
                hasItem[itemIndex] = true;
                inventorySlotImage[itemIndex].enabled = true;

                //hold the item that was picked up just now
                EquipItem(itemIndex);

                //DEBUG: 
                Debug.Log("Item is now in index: " + itemIndex);
                Destroy(item); //destroy the dropped item that was on the ground after it's picked up
            }
        }
    }


}

public class ItemDrop : MonoBehaviour
{
    public int itemIndex; //store the index of the item for pickup
}
