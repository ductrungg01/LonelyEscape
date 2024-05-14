using System.IO;
using UnityEngine;

public static class ScoreSaver
{
    private const string fileName = "score.json"; // File name for storing score

    public static void SaveScore(int score)
    {
        // Create a new ScoreData object with the score
        ScoreData scoreData = new ScoreData(score);

        // Convert ScoreData object to JSON format
        string json = JsonUtility.ToJson(scoreData);

        // Write JSON data to file
        File.WriteAllText(GetFilePath(), json);
    }

    public static int LoadScore()
    {
        // Check if the score file exists
        if (File.Exists(GetFilePath()))
        {
            // Read JSON data from file
            string json = File.ReadAllText(GetFilePath());

            // Convert JSON data back to ScoreData object
            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);

            // Return the score from ScoreData object
            return scoreData.score;
        }
        else
        {
            // If file doesn't exist, return 0
            return 0;
        }
    }

    private static string GetFilePath()
    {
        // Get the path to the persistent data directory
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        return filePath;
    }
}

[System.Serializable]
public class ScoreData
{
    public int score;

    public ScoreData(int score)
    {
        this.score = score;
    }
}
