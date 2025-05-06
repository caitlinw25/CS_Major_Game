using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public static CoinManager instance;
    public int coinCount = 0; //start with 0 coins
    public GameObject CoinObjects; //CoinObjects is the parent object that holds the coin image/icon and text count, it's set on disabled for now

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

    public void AddCoin()
    {
        coinCount++;

        if (coinCount == 1 && CoinObjects != null)
        {
            CoinObjects.SetActive(true); //if the coincount is 1 AND hte coin text and photo is not nothing, then you can show it on the inventory/screen
        }

        FindFirstObjectByType<CoinUI>().UpdateCoinUI(); //update the UI script on the screen
    }

    
}
