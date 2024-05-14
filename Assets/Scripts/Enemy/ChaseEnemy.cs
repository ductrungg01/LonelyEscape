using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    private Transform playerTransform; // Reference to the player's transform
    private Rigidbody rb; // Rigidbody component of the enemy
    private float speed; // Speed of the enemy, 50% of the player's speed
    private float verticalPadding = 1.0f; // Vertical padding from the screen edge

    private Camera mainCamera; // Reference to the main camera

    private bool isTouchPlayer = false; // Flag to check if the enemy has touched the player

    private void Start()
    {
        // Get the player's transform from GameManager
        playerTransform = GameManager.Instance.Player.transform;

        // Get the Rigidbody component of the enemy
        rb = GetComponent<Rigidbody>();

        // Set the speed to be 50% of the player's speed
        speed = GameManager.Instance.Player.GetComponent<PlayerController>().speed * 0.5f;

        // Get the reference to the main camera
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        // Check if the enemy has not touched the player
        if (!isTouchPlayer)
        {
            // Calculate the bottom edge of the screen in world coordinates
            float bottomEdge = mainCamera.ScreenToWorldPoint(new Vector3(0, -Screen.height, 0)).z;

            // Move the enemy towards the player with the set speed
            rb.MovePosition(rb.position + new Vector3(0, 0, 1) * speed * Time.deltaTime);

            // Check if the enemy has reached the bottom edge of the screen
            if (rb.position.z < bottomEdge)
            {
                // Keep the enemy at the bottom edge of the screen
                rb.MovePosition(new Vector3(rb.position.x, rb.position.y, bottomEdge));
            }
        }
    }

    // Triggered when the enemy collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the player
        if (other.CompareTag("Player"))
        {
            // Set the flag to true
            isTouchPlayer = true;

            // Stop the enemy's movement
            this.rb.velocity = Vector3.zero;

            // Call the Die method of the PlayerController to handle the player's death
            GameManager.Instance.Player.GetComponent<PlayerController>().Die();
        }
    }
}
