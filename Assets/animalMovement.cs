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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transoform.position; //establish where they first are
        PickNewDestination(); //call method
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * timer.deltaTime); //makes the animal move to the end position  location

        //if the timer runs out, or the animal reaches that end position, then...
        if (timer <= 0 || Vector3.Distance(transform.position, endPosition) < 0.5f)
        {
            PickNewDestination(); //find a new location for the animal to go to
        }
    }

    void PickNewDestination()
    {
        timer = changeTime; //setting the timer to the value of change time which controls how much time passes before the animal changes direction
        Vector3 randomDirection = new Vector3(randomDirection.Range(-roamRadius, roamRadius),0, random.Range(-roamRadius, roamRadius)); //heading in a random direction
        endPosition = startPosition + randomDirection;
    }
}
