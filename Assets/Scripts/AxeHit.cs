using UnityEngine;

public class AxeHit : MonoBehaviour
{
    //variables
    public float swingAngle = 60f; //rotation of swing
    public float swingSpeed = 2f; 
    private Quaternion originalRotation;
    private bool isSwinging = false;
    private float swingProgress = 0f;

    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isSwinging) //if the player clicks, and the axe is not in hit/swing mode
        {
            isSwinging = true; //turn the axe into swing mode
            swingProgress = 0f; //begin the cycle of one swing
        }

        if (isSwinging)
        {
            swingProgress += Time.deltaTime * swingSpeed; //establish the speed
            float swingAmount = Mathf.Sin(Mathf.Clamp01(swingProgress) * Mathf.PI); //YOUTUBE
            float currentAngle = swingAmount * swingAngle; //ensure the proper angle and swing amount
            transform.localRotation = originalRotation * Quaternion.Euler(-currentAngle, 0f, 0f); //YOUTUBE

            if (swingProgress >= 1f) //if one swing is done, then reput the axe into resting mode
            {
                isSwinging = false;
                transform.localRotation = originalRotation;
            }
        }
    }
}
