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
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipItem(0); //if 1 is clicked, first object
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipItem(1); //if 2 is clicked, second object in inventory
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipItem(2); //goes on
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipItem(3);
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

}
