using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // All class variables

    [SerializeField] private GameObject ZombiePrefab;  // Zombie prefab to spawn
    [SerializeField] private float MinimumSpawnTime;   // Min time between zombie spawns
    [SerializeField] private float MaxSpawnTime;       // Max time between zombie spawns
    [SerializeField] private int NumberOfSpawns;       // target number of zombie spawns


    // Beginning of Class Functions
    private IEnumerator GetTimeBeforeNextSpawn()                                              // Coroutine for spawning zombies at the right intervals
    {
        for (int i = 0; i < NumberOfSpawns; i++)                                              // Loops for however many zombies should spawn
        {
            float TimeBeforeNextSpawn = Random.Range(MinimumSpawnTime, MaxSpawnTime);         // Gets a random number for the spawn time between min and max
            yield return new WaitForSeconds(TimeBeforeNextSpawn);                             // Waits for specified spawn time
            Instantiate(ZombiePrefab, new Vector3(18, RowDecider(), 0), Quaternion.identity); // Instantiates zombie prefab in randoms rows just off screen
        }
    } // End of Function

    private int RowDecider()                      // Returns a random row number for use in zombie spawning
    {
        return ((Random.Range(1, 5) * 2) - 1);    // Returns a random row number multiplied by two and then minus 1 for the world space units of that row.
    } // End of Function

    private void Start()
    {
        StartCoroutine(GetTimeBeforeNextSpawn()); // Starts the zombie spawning Corountine on instantiation of object
    } // End of Function
}// End of Class
