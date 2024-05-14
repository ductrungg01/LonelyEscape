using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public GameObject background1; // The first background GameObject
    public GameObject background2; // The second background GameObject

    private BoxCollider groundCollider; // Collider component of the ground
    private float groundVerticalLength; // Vertical length of the ground based on the collider

    private bool is_bg1 = true; // Flag to track which background is currently active

    private bool is_reposition = false; // Flag to prevent repeated repositioning
    private Transform playerTransform; // Reference to the player's transform

    private void Start()
    {
        // Get the BoxCollider component from background1
        groundCollider = background1.GetComponent<BoxCollider>();
        // Calculate the vertical length of the ground
        groundVerticalLength = groundCollider.size.z * background1.transform.localScale.z;

        // Get the player's transform from GameManager
        playerTransform = GameManager.Instance.Player.transform;
    }

    private void FixedUpdate()
    {
        // Determine the current z position based on which background is active
        float currZ = (is_bg1 ? background1.transform.position.z : background2.transform.position.z);

        // Check if the player's z position is greater than the current background's z position
        if (playerTransform.position.z > currZ && !is_reposition)
        {
            // Get the Rigidbody component of the inactive background
            Rigidbody rb = (is_bg1 ? background2.GetComponent<Rigidbody>() : background1.GetComponent<Rigidbody>());

            // Reposition the background by moving it up by twice its vertical length
            rb.MovePosition(rb.position + new Vector3(0, 0, 2 * groundVerticalLength));

            // Set the reposition flag to true to prevent repeated repositioning
            is_reposition = true;
        }

        // Check if the player's z position is greater than half of the current background's vertical length
        if (playerTransform.position.z > currZ + groundVerticalLength / 2)
        {
            // Reset the reposition flag
            is_reposition = false;

            // Switch the active background
            is_bg1 = !is_bg1;
        }
    }
}
