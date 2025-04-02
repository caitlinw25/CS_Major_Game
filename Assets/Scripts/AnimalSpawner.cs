using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int numAnimalstoSpawn;
    public Vector3 spawnArea = new Vector3(6000f, 1000f, 6000f);


    void Start()
    {
        SpawnAnimals();
    }

    void SpawnAnimals()
    {
        for (int i = 0; i < numAnimalstoSpawn; i++)
        {
            Vector3 randomPosition = getRandomSpawnPos();
            GameObject randomAnimal = animalPrefabs[Random.Range(0, animalPrefabs.Length)]; //grab a random animal prefab from the array
            Instantiate(randomAnimal, randomPosition, Quaternion.identity); //spawn it
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