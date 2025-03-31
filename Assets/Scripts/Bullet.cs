using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletSpeed, lifeTime;
    public Rigidbody theRigidbody; 
    public int damage;

    void Start()
    {
        //establishing speed of bullet when traveling
        theRigidbody.linearVelocity = transform.forward * bulletSpeed;
    }

    
    // Update is called once per frame
    void Update()
    {

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().DamageDone(damage);
            //if the object the bullet collides with something called "enemy", then grab the gameObject from the EnemyHealth script and
            //call the damage function that decreases current enemy health

        }

        if(other.gameObject.tag == "Animal")
        {
            other.gameObject.GetComponent<animalMovement>().DamageDone(damage);
        }

        //when in contact, bullet destory/disapears
        //Destroy(gameObject);
    }
}
