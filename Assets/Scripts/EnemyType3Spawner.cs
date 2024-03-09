using System.Threading;
using UnityEngine;

public class EnemyType3Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public float spawnInterval = 2f; // Time interval between enemy spawns
    public float moveSpeedV = 3f; // Speed at which the enemy moves vertically
    public float moveSpeedH = 8f; // Speed at which the enemy moves horizontally

    private Transform player; // Reference to the player's transform
    private GameObject enemyHolder; // GameObject to hold all spawned enemies
    private float timer = 0f; // Timer to keep track of spawn intervals

    private Transform leftWall; // Reference to the left wall transform
    private Transform rightWall; // Reference to the right wall transform

    void Start()
    {
        // Create an empty GameObject to hold spawned enemies
        enemyHolder = new GameObject("EnemyHolder");

        // Find the player GameObject and get its transform
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        leftWall = GameObject.FindGameObjectWithTag("Wall")?.transform;
        rightWall = GameObject.FindGameObjectWithTag("Wall")?.transform;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Spawn a new enemy
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy prefab at a random position off-screen
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Set the parent of the enemy GameObject to the enemyHolder
        newEnemy.transform.SetParent(enemyHolder.transform);

        // Pass the player reference to the enemy's controller script
        EnemyController3 enemyController = newEnemy.AddComponent<EnemyController3>();

        //This part doesn't work for some reason?
        int randomDir = Random.Range(0, 1);
        if (randomDir == 0)
        {
            randomDir = 1;
        }
        else if (randomDir == 1)
        {
            randomDir = -1;
        }
        enemyController.Initialize(player, leftWall, rightWall, randomDir, moveSpeedH, moveSpeedV);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        spawnPosition = new Vector3(Random.Range(-7, 7), 7, 0);

        return spawnPosition;
    }
}

public class EnemyController3 : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    private Transform leftWall; // Reference to the left wall transform
    private Transform rightWall; // Reference to the right wall transform
    private float speedH = 5f; // Speed at which the enemy moves towards the player
    private float speedV = 5f; // Speed at which the enemy moves horizontally
    private int spawnDirection;

    public void Initialize(Transform playerTransform, Transform leftWallTransform, Transform rightWallTransform, int spawnDir, float moveSpeedH, float moveSpeedV)
    {
        player = playerTransform;
        spawnDirection = spawnDir;
        speedH = moveSpeedH * spawnDir;
        speedV = moveSpeedV;
        leftWall = leftWallTransform;
        rightWall = rightWallTransform;
    }

    void Update()
    {
        if (player != null)
        {
            // Move
            transform.position = new Vector2(transform.position.x + speedH, transform.position.y - speedV);

            // Check if the enemy has reached Wall
            if (transform.position.x > 9 || transform.position.x < -9 )
            {
                speedH = -speedH;
            }

        }
        else
        {
            // If player is null (destroyed or not found), just destroy the enemy
            Destroy(gameObject);
        }
    }
}