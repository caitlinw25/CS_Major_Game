using UnityEngine;

public class TreeHealth : MonoBehaviour
{

    public int currentHealth;
    public GameObject wood;

    public void DamageDone(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Vector3 woodPos = transform.position;
            Destroy(gameObject);
            Instantiate(wood, woodPos, Quaternion.identity); //when the tree dies, instantiate wood
        }
    }

}
