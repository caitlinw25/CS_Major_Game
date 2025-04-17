using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); //get the health of the player from other script

            if(playerHealth != null)
            {
                playerHealth.takeDamage(damage);
            }
        }
    }
}
