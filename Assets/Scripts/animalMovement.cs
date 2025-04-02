using UnityEngine;

public class animalMovement : MonoBehaviour
{

    //variables

    //movement variables (like speed, their limiations of movement etc.)
    public float speed = 2f; 
    public float roamRadius = 10f;
    public float changeTime = 3f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timer;

    //variables for gravity
    public Rigidbody theRigidbody;
    public float gravity = -10;
    private Vector3 velocity;

    //coin appears variables
    public GameObject Coin;

    //health variables
    public int currentHealth;

    public void DamageDone(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Vector3 coinPosition = transform.position;
            Destroy(gameObject);
            Instantiate(Coin, coinPosition, Quaternion.identity);
        }
    }


    void Start()
    {
        startPosition = transform.position; //establish where they first are
        PickNewDestination(); //call method
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime); //makes the animal move to the end position location

        //rotate the animal in the direction of which it's moving
        Vector3 direction = (endPosition - transform.position).normalized;
        Vector3 velocity = direction * speed; //velocity of animal
        theRigidbody.linearVelocity = new Vector3(velocity.x, theRigidbody.linearVelocity.y, velocity.z); //keeping the animal on the terrain (at the y velo)

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //keep Y rotation locked (it doesn't change up or down movement)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }

        //if the timer runs out, or the animal reaches that end position, then...
        if (timer <= 0 || Vector3.Distance(transform.position, endPosition) < 0.5f)
        {
            PickNewDestination(); //find a new location for the animal to go to
        }


    }

    void PickNewDestination()
    {
        timer = changeTime; //setting the timer to the value of change time which controls how much time passes before the animal changes direction
        Vector3 randomDirection = new Vector3(Random.Range(-roamRadius, roamRadius),0, Random.Range(-roamRadius, roamRadius)); //heading in a random direction
        endPosition = startPosition + randomDirection;
    }


}
