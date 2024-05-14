using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    // Triggered when the gift collider collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the player
        if (other.CompareTag("Player"))
        {
            // Increment the player's points
            PointHolder.Instance.points++;

            // Destroy the gift object
            Destroy(gameObject);
        }
    }
}
