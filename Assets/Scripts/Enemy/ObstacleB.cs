using System.Collections;
using UnityEngine;

public class ObstacleB : MonoBehaviour, IObstacle
{
    private Collider collider; // Collider component of the obstacle

    public float timeToReturnToPool = 20; // Time before returning the obstacle to the pool
    public Material originalMaterial; // Original material of the obstacle

    private void Start()
    {
        // Reset the material of the obstacle
        ResetMaterial();

        // Get the collider component
        collider = GetComponent<Collider>();

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

        // Deactivate the collider for a certain duration
        StartCoroutine(DeactivateColliderForSeconds(3f));
    }

    // Deactivate the collider of the obstacle
    public void DeactivateCollider()
    {
        collider.enabled = false;
    }

    // Coroutine to deactivate the collider for a certain duration
    IEnumerator DeactivateColliderForSeconds(float seconds)
    {
        // Deactivate the collider
        DeactivateCollider();

        // Wait for the specified duration
        yield return new WaitForSeconds(seconds);

        // Return the obstacle to the pool
        _ = PoolManager.Instance.ObstacleB_pooler.OnReturnToPool(this.gameObject);
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
