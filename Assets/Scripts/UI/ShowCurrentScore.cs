using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCurrentScore : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TMP_Text component to display the score

    // Update is called once per frame
    void Update()
    {
        // Update the score text to display the current score from PointHolder
        scoreText.text = $"Current score: {PointHolder.Instance.points}";
    }
}
