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

        //unlock the cursor so that it is able to click the button
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) //if 2 is pressed
        {
            beginGame();
        }
    }

    public void beginGame()
    {
        //DEBUG: the button isn't doing anything, check if it's clicked or not
        //Debug.Log("CLICKED"); - doesn't work with the Web game

        startScreen.SetActive(false); //hide the start screen
        Time.timeScale = 1f; //unfreeze game

        //lock the cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
