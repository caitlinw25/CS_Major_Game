using UnityEngine;

public class WoodManager : MonoBehaviour
{
    public static WoodManager instance;
    public int woodCount = 0; //start with 0 coins
    public GameObject woodObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddWood()
    {
        woodCount++;

        if (woodCount == 1 && woodObjects != null)
        {
            woodObjects.SetActive(true);
        }

        FindFirstObjectByType<WoodText>().UpdateWoodUI();

    }

}
