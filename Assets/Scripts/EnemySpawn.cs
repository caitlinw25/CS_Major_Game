using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int numEnemiesSpawn;
    public Vector3 spawnArea = new Vector3(6000f, 1000f, 6000f);
    public TimeManager timeManager; //so we can reference the time manager script


    void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        //keep checking if it's day
        if(timeManager.isDay) //if it's day
        {
            DestroyAllEnemies();
        }
    }

    void SpawnEnemies()
    {
        if(timeManager.isNight) //if it's night, spawn the enemies randomly
        {
            for(int i = 0; i < numEnemiesSpawn; i++ )
            {
                Vector3 randomPosition = getRandomSpawnPos();
                Instantiate(enemy, randomPosition, Quaternion.identity); //spawn it at random position
            }
        }
    }

    Vector3 getRandomSpawnPos()
    {
        //get random y and x loc
        float x = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        float z = Random.Range(-spawnArea.z / 2, spawnArea.z / 2);
        float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)); //make sure y loc matches

        return new Vector3(x, y, z);
    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //create a list of all items in scene with an enemy tag

        //take each of these enemies in the array and destory them
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }


}
