using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    // All class variables
    private SceneLoaderScript sceneLoader;             // Empty SceneLoaderScript varaible for use up later
    [SerializeField] private GameObject SceneLoader;   // Reference to the current SceneLoader object
    [SerializeField] private AudioClip deathNoise;     // Reference to the desired death noise audio clip
    [SerializeField] private float deathNoiseLength;   // Desired length of death noise
    

    // Beginning of call functions
    private void Start()
    {
        sceneLoader = SceneLoader.GetComponent<SceneLoaderScript>();  // Gets SceneLoaderScript component from SceneLoader object
    } // End of Function

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))                   // If collision is from an "enemy"
        {
            StartCoroutine(WaitForDeathSound());          // Starts the Wait for death sound coroutine
        }
    } // End of Function

    private IEnumerator WaitForDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathNoise, Camera.main.transform.position); // Plays the death sound clip at the cameras position
        yield return new WaitForSeconds(deathNoiseLength);                       // Waits the length of time specified so the clip can finish
        sceneLoader.LoadGameOver();                                              // Load the game over scene
    } // End of Function
} // End of Class
