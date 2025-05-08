using UnityEngine;

public class shooting : MonoBehaviour
{
    //bullet movement variables
    public GameObject bullet;
    private Transform firePoint;
    public AudioSource gunShot;

    void Start()
    {
        //find bullet spawn object under gun and then use that as loc for bullet spawn
        firePoint = transform.Find("Bullet Spawn");


        /*
        if (firePoint == null) //will show if there is no spawn point assigned to the prefab
        {
            Debug.LogError("Bullet spawn point empty object not found");
        }
        */


    }

    // Update is called once per frame
    void Update()
    {
        //if I click, a bullet shoots out from the firePoint position
        if(Input.GetMouseButtonDown(0))
        {
            //create a bullet when click
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            gunShot.Play();

        }

    }

    
}
