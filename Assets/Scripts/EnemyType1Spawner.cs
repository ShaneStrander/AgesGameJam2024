using UnityEngine;

public class EnemyType1Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public float spawnInterval = 2f; // Time interval between enemy spawns
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the player

    private Transform player; // Reference to the player's transform
    private GameObject enemyHolder; // GameObject to hold all spawned enemies
    private float timer = 0f; // Timer to keep track of spawn intervals

    void Start()
    {
        // Create an empty GameObject to hold spawned enemies
        enemyHolder = new GameObject("EnemyHolder");

        // Find the player GameObject and get its transform
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
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
        EnemyController enemyController = newEnemy.AddComponent<EnemyController>();
        enemyController.Initialize(player, moveSpeed);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Randomly select a side of the screen (top, bottom, left, right)
        int side = Random.Range(0, 4);
        Vector3 spawnPosition = Vector3.zero;

        // Calculate spawn position based on the selected side
        switch (side)
        {
            case 0: // Top
                spawnPosition = new Vector3(Random.Range(-10f, 10f), 6f, 0f);
                break;
            case 1: // Bottom
                spawnPosition = new Vector3(Random.Range(-10f, 10f), -6f, 0f);
                break;
            case 2: // Left
                spawnPosition = new Vector3(-12f, Random.Range(-6f, 6f), 0f);
                break;
            case 3: // Right
                spawnPosition = new Vector3(12f, Random.Range(-6f, 6f), 0f);
                break;
        }

        return spawnPosition;
    }
}

public class EnemyController : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    private float moveSpeed = 5f; // Speed at which the enemy moves towards the player

    public void Initialize(Transform playerTransform, float speed)
    {
        player = playerTransform;
        moveSpeed = speed;
    }

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Calculate the direction to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Rotate the enemy to face the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            // Check if the enemy has reached the player
            if (Vector2.Distance(transform.position, player.position) < 0.1f)
            {
                // If so, destroy the enemy
                Destroy(gameObject);
            }
        }
        else
        {
            // If player is null (destroyed or not found), just destroy the enemy
            Destroy(gameObject);
        }
    }
}