using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPreviousPoint : MonoBehaviour
{
    public TMP_Text previousScoreText; // Reference to the TMP_Text component to display the previous score

    private void Start()
    {
        // Load the previous score from the JSON file using the LoadScore method from ScoreSaver
        int previousScore = ScoreSaver.LoadScore();

        // Update the previous score text to display the loaded score
        previousScoreText.text = "Previous Score: " + previousScore.ToString();
    }
}
