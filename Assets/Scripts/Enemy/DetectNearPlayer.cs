using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNearPlayer : MonoBehaviour
{
    public float distance = 1.0f; // Distance threshold to detect the player
    private Transform player_transform; // Reference to the player's transform

    public Material nearPlayerMaterial; // Material to apply when near the player

    private void Start()
    {
        // Get the player's transform from GameManager
        player_transform = GameManager.Instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the distance between this object and the player is less than the specified distance
        if (Vector3.Distance(player_transform.position, this.transform.position) < distance)
        {
            // Change the material of the object to nearPlayerMaterial
            this.gameObject.GetComponent<Renderer>().material = nearPlayerMaterial;
        }
    }
}
