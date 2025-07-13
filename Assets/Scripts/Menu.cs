using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene (assuming it's named "Game")
        SceneManager.LoadScene("Gameplay"); // Ensure AudioManager is initialized
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
