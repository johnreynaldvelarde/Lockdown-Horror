using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject killerBunnyPrefab; // Reference to the Killer_Bunny prefab
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 60f; // Time interval to spawn the enemy (in seconds)
    private float spawnTimer; // Timer to keep track of spawning

    void Start()
    {
        spawnTimer = spawnInterval; // Start the timer
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime; // Count down the timer

        if (spawnTimer <= 0f)
        {
            SpawnKillerBunny(); // Spawn a Killer_Bunny
            spawnTimer = spawnInterval; // Reset the timer
        }
    }

    void SpawnKillerBunny()
    {
        if (spawnPoints.Length > 0)
        {
            // Choose a random spawn point from the array
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnLocation = spawnPoints[randomIndex];

            // Instantiate the Killer_Bunny prefab at the chosen spawn point
            Instantiate(killerBunnyPrefab, spawnLocation.position, spawnLocation.rotation);

            Debug.Log("Killer_Bunny spawned at: " + spawnLocation.position);
        }
        else
        {
            Debug.LogWarning("No spawn points assigned in the SpawnManager.");
        }
    }
}
