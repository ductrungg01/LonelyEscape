using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 10; // Initial health of the player
    private int currentHealth; // Current health of the player
    public Slider healthSlider; // Reference to the health slider UI component

    private void Start()
    {
        // Initialize current health to start health
        currentHealth = startHealth;

        // Set the initial value of the health slider to full
        healthSlider.value = 1;
    }

    // Method called when the player takes damage
    public void OnTakeDamage(int healthLost)
    {
        // Reduce the current health by the amount of health lost
        this.currentHealth -= healthLost;

        // Ensure current health doesn't go below zero
        this.currentHealth = Mathf.Max(currentHealth, 0);

        // Update the health slider value
        healthSlider.value = (float)currentHealth / startHealth;

        // Check if the player's health has reached zero or below
        if (currentHealth <= 0)
        {
            // Call the Die method of the PlayerController
            this.GetComponent<PlayerController>().Die();
        }
    }
}
