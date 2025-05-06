using UnityEngine;

public class HandHolderManage : MonoBehaviour
{

    public Transform handHolder;
    public GameObject[] objectsHeld;
    public GameObject currentItemHeld;
    private int currentIndex = -1;


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
            Debug.Log("Item is already there at index: " + index + ", skipping.");
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

        //it's placed in front of player AND it's on the terrain ground
        Vector3 dropDirection = Camera.main.transform.forward;
        Vector3 dropPos = handHolder.position + dropDirection * 15f;
        dropPos.y = Terrain.activeTerrain.SampleHeight(dropPos) + Terrain.activeTerrain.transform.position.y;
        dropped.transform.position = dropPos;

        if (currentIndex == 1 || currentIndex == 2)
        {
            dropped.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }


    }
}
