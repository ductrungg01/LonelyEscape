using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHolder : MonoBehaviour
{
    // Singleton instance
    public static PointHolder Instance { get; private set; }

    // Variable to store points
    [HideInInspector]
    public int points = 0;

    private void Awake()
    {
        // Check if an instance of the Singleton already exists
        if (Instance == null)
        {
            // If not, set this instance as the Singleton instance
            Instance = this;
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }
}
