using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPointInResultScene : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TMP_Text component to display the score

    private void Start()
    {
        // Retrieve the saved point from PlayerPrefs
        int point = PlayerPrefs.GetInt("point", 0);

        // Update the score text to display the retrieved point
        scoreText.text = point.ToString();

        // Save the point to a JSON file
        SavePointToJson(point);
    }

    // Save the point to a JSON file
    void SavePointToJson(int point)
    {
        // Call the SaveScore method from the ScoreSaver class to save the point
        ScoreSaver.SaveScore(point);
    }
}
