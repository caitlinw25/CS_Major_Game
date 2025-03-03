using UnityEngine;
using TMPro;

public class killed : MonoBehaviour
{

    private TextMeshProUGUI numEnemyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numEnemyText = GetComponent<TextMeshProUGUI>();
    }

    public void updateText(EnemiesKilled enemiesKilled)
    {
        numEnemyText.text = enemiesKilled.numEnemies.ToString();
    }

}
