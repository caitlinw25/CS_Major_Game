using UnityEngine;

public class POVController : MonoBehaviour
{

    //variables for the diff states, objects, etc. to reference
    private enum DiffState {FirstPerson, ThirdPerson};
    private DiffState currentState = DiffState.FirstPerson; //set the current to first pov
    public Camera firstPOVCam;
    public Camera thirdPOVCam;
    public GameObject mouseLookScript;
    public Transform thirdPersonLoc;
    public GameObject uiCanvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPOV(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ChangePOV();
        }

        if(currentState == DiffState.ThirdPerson)
        {
            thirdPOVCam.transform.LookAt(mouseLookScript.transform.position + Vector3.up * 1.5f); //the third person camera will move with the mouse look script
        }
    }

    void ChangePOV()
    {
        currentState = (currentState == DiffState.FirstPerson) ? DiffState.ThirdPerson : DiffState.FirstPerson; //works like an if algorithm but shortned
        //if we're in first person, switch to third, and vice versa
        SetPOV(currentState);
    }

    void SetPOV(DiffState state)
    {
        if(state == DiffState.FirstPerson)
        {
            firstPOVCam.enabled = true; //turn the first pov camera on and third pov one off
            thirdPOVCam.enabled = false;
            mouseLookScript.SetActive(true); //let the mouse script controll the camera
            uiCanvas.SetActive(true);
        }
        else
        {
            firstPOVCam.enabled = false;
            thirdPOVCam.enabled = true;
            mouseLookScript.SetActive(true); //disable the mouse script to prevent conflicts with rotation
            uiCanvas.SetActive(false); //makes inventory and stuff disapear
        }
    }
}
