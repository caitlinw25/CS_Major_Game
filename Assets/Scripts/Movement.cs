using UnityEngine;

public class Movement : MonoBehaviour
{
    
    //object variables
    public CharacterController controller;


    //movement variables 
    public float speed = 70f;
    public float fastSpeed = 80f;
    public float gravity = -20000f; //need it to pull down wayyy stronger
    public float jumpHeight = 100f;
    Vector3 velocity;
    bool isGrounded;


    //detecting the "w" double tap for speed variables
    private float firstPressTime = 0;
    private float timeBetweenTaps = 0.2f; 
    private bool isSprinting = false;

    
    //bullet movement variables
    public GameObject bullet;
    public Transform firePoint;
    
    
    //enemy movement variables
    public static Movement instance;
    
    private void Awake()
    {
        instance = this;
    } 


    void Start()
    {
        Cursor.visible = false;
    }


    
    void Update()
    {
        //if the player is on the ground and velocity is less than 0...
        isGrounded = controller.isGrounded;

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // normal velocity when on ground
        }


        //checking for the double tap of "w" key
        if (Input.GetKeyDown(KeyCode.W))
        {
            //if the user taps between the time given above (0.3)
            if (Time.time - firstPressTime < timeBetweenTaps) 
            {
                //they will sprint!
                isSprinting = true;
            }
            firstPressTime = Time.time;
        }

        //get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //change the speed according to if the player is sprinting
        float currentSpeed;
        if (isSprinting)
        {
            currentSpeed = fastSpeed;
        }
        else
        {
            currentSpeed = speed;
        }



        //use input to turn into direction (in the way that the player is facing)
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity) * 5; //equation to find velocity to reach that height
        }

        //stoping the sprint
        if (Input.GetKeyUp(KeyCode.W))
        {
            isSprinting = false;
        }

        //applying gravity

        velocity.y += gravity * 10f * Time.deltaTime; //making the gravity stronger

        controller.Move(velocity * Time.deltaTime);


        //if I click, a bullet shoots out from the firePoint position
        if(Input.GetMouseButtonDown(0))
        {

            //create a bullet when click
            Instantiate(bullet, firePoint.position, firePoint.rotation);

        }



    }
}
