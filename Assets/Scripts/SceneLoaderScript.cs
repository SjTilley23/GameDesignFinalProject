using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{

    // Beginning of class functions
    public void LoadLevel(string levelName)      // Loads scene based on inputted name
    {
        SceneManager.LoadScene(levelName);
    } // End of Function

    public void LoadGameOver()                   // Loads GameOver Scene
    {
        SceneManager.LoadScene("GameOver");
    } // End of Function

    public void LoadStartMenu()                  // Loads StartMenu Scene
    {
        SceneManager.LoadScene("StartMenu");
    } // End of Function

    public void QuitGame()                       // Quits the game
    {
        Application.Quit();
    } // End of Function
} // End of Class
