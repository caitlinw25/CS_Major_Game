using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    //variables
    public GameObject[] treePrefabs;
    public int numTreesSpawn;
    public Vector3 spawnArea = new Vector3(6000f, 1000f, 6000f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        for (int i = 0; i < numTreesSpawn; i++)
        {
            Vector3 randomPosition = getRandomSpawnPos();
            GameObject randomTree = treePrefabs[Random.Range(0, treePrefabs.Length)]; //grab a random tree prefab from the array
            Instantiate(randomTree, randomPosition, Quaternion.identity); //spawn it
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

    
}
