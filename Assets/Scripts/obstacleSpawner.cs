using UnityEngine;
using System.Collections.Generic;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab of the object to spawn
    public List<GameObject> tokens = new List<GameObject>(); // List to store references to token options
    public float spawnInterval = 2f; // Time interval between spawns
    public float minX = -5f; // Minimum X position of spawning
    public float maxX = 5f; // Maximum X position of spawning
    public float despawnY = -10f; // Y position below which objects are despawned
    public float fallSpeed = 5f; // Speed at which the objects fall

    private float timer;
    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to store references to spawned objects
    
    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new object
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f; // Reset timer
        }

        // Update all spawned objects
        UpdateSpawnedObjects();
    }

    void SpawnObject()
    {
        // Calculate random X position within the given range
        float randomX = Random.Range(minX, maxX);
        //Random.Range(0, 10) can return a value between 0 and 9
        int chance = Random.Range(0, 10);

        GameObject newObject;

        if(chance == 9){
            int rand = Random.Range(0, 3);
            newObject = Instantiate(tokens[rand], new Vector3(randomX, 10, -1), Quaternion.identity);
        }
        else{
            // Instantiate object at calculated position
            newObject = Instantiate(objectPrefab, new Vector3(randomX, 10, -1), Quaternion.identity);
        }
        // Add reference to the spawned object
        spawnedObjects.Add(newObject);
    }

    void UpdateSpawnedObjects()
    {
        
        // Iterate over spawned objects in reverse order
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i])
            {
                GameObject obj = spawnedObjects[i];

                // Move the object downwards
                obj.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

                // Check if the object falls below the despawn Y position
                if (obj.transform.position.y < despawnY)
                {
                    // Remove the object from the list
                    spawnedObjects.RemoveAt(i);

                    // Destroy the object
                    Destroy(obj);
                }
            }
            else
            {
                // Remove the object from the list
                spawnedObjects.RemoveAt(i);
            }
        }
    }
}
