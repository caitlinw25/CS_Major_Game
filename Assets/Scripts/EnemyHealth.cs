using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageDone(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject); //destory enenmy if out of health
        }
    }
}