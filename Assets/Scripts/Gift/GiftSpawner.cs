using Cysharp.Threading.Tasks;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    public GameObject prefab; // The prefab of the GameObject to spawn
    private Transform playerTransform; // The Transform of the Player
    public float maxDistance = 5f; // The maximum distance between the GameObject and Player
    public float spawnInterval = 10f; // The time interval between spawns (10 seconds)

    private void Start()
    {
        // Start the coroutine to spawn GameObjects at intervals
        SpawnObjectWithDelay().Forget();

        // Get the player's transform from the GameManager
        playerTransform = GameManager.Instance.Player.transform;
    }

    // Coroutine to spawn GameObjects at intervals
    async UniTaskVoid SpawnObjectWithDelay()
    {
        while (true)
        {
            // Wait until the next spawn time
            await UniTask.Delay((int)(spawnInterval * 1000), cancellationToken: this.GetCancellationTokenOnDestroy());

            // Generate a random position within maxDistance from the Player
            Vector3 randomPosition = GetRandomPosition();

            // Instantiate the GameObject at the random position
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }

    // Generate a random position within maxDistance from the Player
    Vector3 GetRandomPosition()
    {
        // Generate a random direction within a sphere of radius maxDistance
        Vector3 randomDirection = Random.insideUnitSphere * maxDistance;

        // Offset the random direction by the Player's position
        randomDirection += playerTransform.position;

        // Ensure the random position has the same y-coordinate as the Player's position
        randomDirection.y = playerTransform.position.y;

        return randomDirection;
    }
}
