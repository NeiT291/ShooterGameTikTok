using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(false); // Hide the Game Over screen
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
