using UnityEngine;

public class AxeHit : MonoBehaviour
{
    //variables
    public float swingAngle = 60f; //rotation of swing
    public float swingSpeed = 5f; 
    private Quaternion originalRotation;
    private bool isSwinging = false;
    private float swingProgress = 0f;
    public int damage;

    //variables for the raycast/hitting in the middle of screen
    public Camera characterCamera;

    
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

                RaycastHit hit; //establish a raycast
                if (Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit))
                {
                    //DEBUG: show what the axe has hit, the animals aren't dying. Check to see if they are being hit or not
                    Debug.Log("What was hit: " + hit.collider.name);

                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.GetComponent<EnemyHealth>().DamageDone(damage);
                    }
                    else if (hit.collider.CompareTag("Animal"))
                    {
                        hit.collider.GetComponent<animalMovement>().DamageDone(damage);
                    }
                    else if (hit.collider.CompareTag("Tree"))
                    {
                        hit.collider.GetComponent<TreeHealth>().DamageDone(damage);
                    }
                }
            }
        }
    }

}
