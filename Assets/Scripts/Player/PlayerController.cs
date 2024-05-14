using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the character
    private bool isMovingWithMouse = false; // Flag to check if moving with mouse
    private Vector3 mouseStartPosition; // Mouse start position for movement calculation
    private Rigidbody rb; // Reference to the Rigidbody component

    private void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Update method is empty as we handle movement in FixedUpdate
    }

    private void FixedUpdate()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            isMovingWithMouse = true;
            mouseStartPosition = Input.mousePosition; // Set mouse start position
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            isMovingWithMouse = false;
        }

        // Move the character
        Move();
    }

    // Handle character movement
    void Move()
    {
        // Get input from keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction from keyboard
        Vector3 keyboardMovement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

        // Calculate movement direction from mouse if flag is true
        Vector3 mouseMovement = Vector3.zero;
        if (isMovingWithMouse)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseInput = (currentMousePosition - mouseStartPosition).normalized;
            mouseMovement = new Vector3(mouseInput.x, 0, mouseInput.y) * speed * Time.deltaTime;
        }

        Vector3 movement = keyboardMovement + mouseMovement;

        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + movement);
    }

    // Method called when the player dies
    public void Die()
    {
        // Save the current points and show the result scene
        GameManager.Instance.SavePoint();
        Debug.Log("Die");
    }
}
