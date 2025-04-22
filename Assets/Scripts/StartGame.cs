using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject startScreen;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f; //begin the game with a frozen screen so the player can't move around before pressing start button
        startScreen.SetActive(true); //show the start button
    }

    public void beginGame()
    {
        //DEBUG: the button isn't doing anything, check if it's clicked or not
        Debug.Log("CLICKED");

        startScreen.SetActive(false); //hide the start screen
        Time.timeScale = 1f; //unfreeze game
    }
}
