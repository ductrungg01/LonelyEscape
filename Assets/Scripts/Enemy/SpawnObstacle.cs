using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float spawnInterval = 3.0f; // Interval between spawning obstacles
    public float distanceToSpawnZ = 5.0f; // Distance along the Z-axis to spawn obstacles
    public float distanceToSpawnX = 5.0f; // Maximum distance along the X-axis to spawn obstacles

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning obstacles
        SpawnObstacles();
    }

    // Coroutine to spawn obstacles
    private async void SpawnObstacles()
    {
        while (true) // Infinite loop to keep spawning obstacles
        {
            // Randomly select between obstacle A and B
            bool isObstacleA = Random.value > 0.5f;

            // Check if the player exists
            if (GameManager.Instance.Player == null) return;

            // Get the player's transform and position
            Transform player_transform = GameManager.Instance.Player.transform;
            Vector3 player_pos = player_transform.position;

            // Calculate the spawn position based on player's position and random offsets
            Vector3 spawnPos = player_pos + new Vector3((Random.value - 0.5f) * distanceToSpawnX, 0, distanceToSpawnZ);

            if (isObstacleA)
            {
                // Take an obstacle A from the pool and reset its material
                GameObject go = PoolManager.Instance.ObstacleA_pooler.OnTakeFromPool(spawnPos, Quaternion.identity);
                if (go)
                    go.GetComponent<ObstacleA>().ResetMaterial();
            }
            else
            {
                // Take an obstacle B from the pool and reset its material
                GameObject go = PoolManager.Instance.ObstacleB_pooler.OnTakeFromPool(spawnPos, Quaternion.identity);
                if (go)
                    go.GetComponent<ObstacleB>().ResetMaterial();
            }

            // Wait for the specified interval before spawning the next obstacle
            await UniTask.Delay((int)(spawnInterval * 1000));
        }
    }
}
