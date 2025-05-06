using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WoodText : MonoBehaviour
{

    public static WoodText instance;
    public TextMeshProUGUI woodText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateWoodUI();
    }

    // Update is called once per frame
    public void UpdateWoodUI()
    {
        woodText.text = WoodManager.instance.woodCount.ToString();
    }
}
