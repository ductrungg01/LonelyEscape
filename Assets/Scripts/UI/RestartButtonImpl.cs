using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonImpl : MonoBehaviour
{
    // Method to restart the game by loading the "PlayScene"
    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
