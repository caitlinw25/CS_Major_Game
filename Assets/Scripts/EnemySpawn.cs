using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    
    //so we can track players location and spawn around this location
    public Transform player; 

    //variables for spawning
    public float minSpawnLimit = 10f; 
    public float maxSpawnLimit = 50f;
    public float distance;
    private Vector3 locationDistance;
    private Vector3 randomBlahBlah;


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            
            //generates a random distance from the players position using min and max values
            distance = Random.Range(minSpawnLimit, maxSpawnLimit);

            //generating a random angle to use for x and y coordinates
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float displaceX = Mathf.Cos(angle) * distance;
            float displaceZ = Mathf.Sin(angle) * distance;

            //using random coordinates to create a vector for how far it would be placed
            Vector3 locationDistance = new Vector3(displaceX, 0, displaceZ);
            
            //final coordinates of the enemy
            Vector3 enemyRandoLoc = player.position + locationDistance;

            //creates the enemy with those coordinates, makes sure it doesn't rotate
            Instantiate(enemy, enemyRandoLoc, Quaternion.identity); 
        }
    }


}
