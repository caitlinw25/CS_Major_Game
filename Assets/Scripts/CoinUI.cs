using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{

    public static CoinUI instance;
    public TextMeshProUGUI coinText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinUI();
    }

    // Update is called once per frame
    public void UpdateCoinUI()
    {
        coinText.text = CoinManager.instance.coinCount.ToString();
    }
}
