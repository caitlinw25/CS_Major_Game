using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //enemy movement variables
    public float enemySpeed;
    public Rigidbody theRigidbody;

    //gravity variables
    public float gravity = -10;
    private Vector3 velocity;


    // Update is called once per frame
    void Update()
    {
        //look at the Movement script and the instance it created, make the enemy follow this point (the player)
        transform.LookAt(Movement.instance.transform.position);

        //establishing enemy speed
        velocity = transform.forward * enemySpeed;

        //making the enemy have a downward y velocity with gravity
        velocity.y = theRigidbody.linearVelocity.y + (gravity * Time.deltaTime);
        theRigidbody.linearVelocity = velocity;

    }
}
