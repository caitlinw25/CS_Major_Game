using UnityEngine;

public class shooting : MonoBehaviour
{
    //bullet movement variables
    public GameObject bullet;
    public Transform firePoint;

    void Start()
    {
        // Automatically find the child called "FirePoint"
        firePoint = transform.Find("Bullet Spawn");

        if (firePoint == null) //will show if there is no spawn point assigned to the prefab
        {
            Debug.LogError("Bullet spawn point empty object not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if I click, a bullet shoots out from the firePoint position
        if(Input.GetMouseButtonDown(0))
        {
            //create a bullet when click
            Instantiate(bullet, firePoint.position, firePoint.rotation);

        }

    }

    
}
