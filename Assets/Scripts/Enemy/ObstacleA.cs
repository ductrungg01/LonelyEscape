using UnityEngine;

public class ObstacleA : MonoBehaviour, IObstacle
{
    public float timeToReturnToPool = 20; // Time before returning the obstacle to the pool
    public Material originalMaterial; // Original material of the obstacle

    private void Start()
    {
        // Reset the material of the obstacle
        ResetMaterial();

        // Schedule the obstacle to return to the pool after a certain time
        _ = PoolManager.Instance.ObstacleA_pooler.OnReturnToPool(this.gameObject, timeToReturnToPool);
    }

    // Reset the material of the obstacle to its original material
    public void ResetMaterial()
    {
        this.gameObject.GetComponent<Renderer>().material = originalMaterial;
    }

    // Handle when the obstacle is hit by the player
    public void HitByPlayer()
    {
        // Reduce the player's health by 1
        GameManager.Instance.Player.GetComponent<PlayerHealth>().OnTakeDamage(1);

        // Return the obstacle to the pool
        _ = PoolManager.Instance.ObstacleA_pooler.OnReturnToPool(this.gameObject);
    }

    // Implementation of the DeactivateCollider method from the IObstacle interface
    public void DeactivateCollider()
    {
        // Obstacle A doesn't need to implement this method
    }

    // Triggered when the obstacle collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the player
        if (other.CompareTag("Player"))
        {
            // Handle the obstacle being hit by the player
            HitByPlayer();
        }
    }
}
