using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SunProducer : MonoBehaviour
{
    // All class variables

    [SerializeField] private GameObject sunPrefab;  // Reference to the Sun Prefab
    [SerializeField] private float timeBetweenSun;  // Time between sun spawns
    private Animator animator;                      // Empty varaible for animator component

    // Beginning of class functions
    private void Start()
    {
        animator = GetComponent<Animator>();  // Gets handle on animator component
        StartCoroutine(WaitToProduce());      // Starts the wait to produce coroutine
    } // End of Function

    private IEnumerator WaitToProduce()
    {
        while (true) {
            yield return new WaitForSeconds(timeBetweenSun);              // Waits for specified time
            animator.SetTrigger("Produce");                               // Triggers the proper animation
            Vector3 positionToSpawn = new Vector3(transform.position.x,   // Sets vector 3 for use in spawning sun
                transform.position.y, sunPrefab.transform.position.z);
            Instantiate(sunPrefab, positionToSpawn, transform.rotation);  // Spawns sun prefab at plants location
            
        }
    } // End of Function
} // End of Class
