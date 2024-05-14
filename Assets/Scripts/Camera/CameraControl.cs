using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    #region Fields
    public float _DampTime = 0.1f; // Time taken for the camera to reach the desired position and size
    private Transform _PlayerTransform; // Reference to the player's transform

    private Camera _Camera; // Reference to the Camera component
    private float _ZoomSpeed; // Speed of zooming
    private Vector3 _MoveVelocity; // Velocity of camera movement
    private Vector3 _DesiredPosition; // Desired position for the camera
    #endregion

    private void Awake()
    {
        // Get the Camera component from the child objects
        _Camera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        // Get the player's transform from GameManager
        _PlayerTransform = GameManager.Instance.Player.transform;
    }

    private void FixedUpdate()
    {
        // Move the camera to the desired position
        Move();
        // Zoom the camera
        Zoom();
    }

    // Move the camera smoothly to the desired position
    private void Move()
    {
        // Calculate the desired position
        FindDesiredPosition();

        // Smoothly move the camera to the desired position
        transform.position = Vector3.SmoothDamp(transform.position, _DesiredPosition, ref _MoveVelocity, _DampTime);
    }

    // Find the desired position for the camera
    private void FindDesiredPosition()
    {
        // Get the player's transform from GameManager
        _PlayerTransform = GameManager.Instance.Player.transform;

        // Set the desired position to be aligned with the player's position but at the same height as the camera
        _DesiredPosition = _PlayerTransform.position;
        _DesiredPosition.y = transform.position.y;
    }

    // Zoom the camera to a specified size
    private void Zoom()
    {
        // Set the required size for the orthographic camera
        float requiredSize = 20;

        // Smoothly zoom the camera to the required size
        _Camera.orthographicSize = Mathf.SmoothDamp(_Camera.orthographicSize, requiredSize, ref _ZoomSpeed, _DampTime);
    }
}
