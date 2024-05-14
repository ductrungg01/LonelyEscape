using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton instance
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Check if the instance already exists
        if (Instance == null)
        {
            // If not, set the instance to this
            Instance = this;
            // Keep the GameManager alive between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this
            Destroy(gameObject);
        }
    }
    #endregion

    #region Fields
    public GameObject Player; // Reference to the Player GameObject
    #endregion

    // Save the current points and show the result scene
    public void SavePoint()
    {
        // Save the current points to PlayerPrefs
        PlayerPrefs.SetInt("point", PointHolder.Instance.points);

        // Load the result scene
        ShowSceneResult();
    }

    // Load the result scene
    void ShowSceneResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
