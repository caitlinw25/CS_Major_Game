using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth;
    public GameObject bone;

    public void DamageDone(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            FindAnyObjectByType<EnemiesKilled>()?.enemiesKilled(); //makes sure num of enemies increases, no errors yurr
            Destroy(gameObject); //destory enenmy if out of health
        }
    }
}