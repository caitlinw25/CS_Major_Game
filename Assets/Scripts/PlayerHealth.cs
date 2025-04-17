using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //health variables
    public int maxHealth = 100;
    public int currentHealth;

    //displaying the health on screen variables + death screen
    public Slider healthSlide;
    public GameObject deathScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; //begin with full health
        updateHealthUI();
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        updateHealthUI(); //continuesly show/update the health on screen

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void updateHealthUI()
    {
        //if the health slider is assigned an UI object, then assign the health value (current) out of the max health possible
        if(healthSlide != null)
        {
            healthSlide.value = (float)currentHealth / maxHealth; 
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        deathScreen.SetActive(true); 
    }

}
