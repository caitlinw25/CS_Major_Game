using UnityEngine;

public class FootStepSound : MonoBehaviour
{

    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private CharacterController controller;

    // Update is called once per frame
    void Update()
    {
        //create boolean, if the player is moving then whats true is the velocity is big and the player is on the ground
        bool isMoving = controller.isGrounded && controller.velocity.magnitude > 0.1f;

        if (isMoving)
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            if(footstepSound.isPlaying)
            {
                footstepSound.Stop();
            }
        }
    }
}
