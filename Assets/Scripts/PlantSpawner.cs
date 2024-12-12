using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlantSpawner : MonoBehaviour
{
    // All class variables
    [SerializeField] private GameObject countdownTimer;                // Name of the countdown timer game object
    [SerializeField] private float placedPlantWait;                    // Amount of time the player has to wait to place a plant
    [SerializeField] private AudioClip cantPlaceAudio;                 // Audio clip that plays when you can't place a plant
    [SerializeField] private float cantPlaceAudioVolume;               // Volume for can't place audio clip
    [SerializeField] private GameObject packetPlacerObject;            // Packet placer object in scene
    private Cell[] cells;                                              // Empty array of Cell
    private CountdownTimer countdownScript;                            // Empty variable for handling countdown timer script
    private float plantWait;                                           // Empty variable for plant wait timer
    private List<Vector3> currentlyPlacedPlants = new List<Vector3>(); // Empty list to be used for placed plant locations
    private PacketPlacer packetPlacerScript;                           // Empty variable for handling packet placer script


    // Beginning of class functions
    public void SpawnPlayer(Vector3 position_to_spawn)
    {
        if (plantWait == 0)                                                  // If plant is able to be placed
        {   
            if (IsPlantInCell(position_to_spawn))                            // If plant is already in cell
            {
                AudioSource.PlayClipAtPoint(cantPlaceAudio,                  // Plays cant place audio clip at cameras position
                    Camera.main.transform.position, cantPlaceAudioVolume);
            }
            else                                                                        // If plant is not in cell
            {
                Instantiate(packetPlacerScript.currentlySelectedPlant,                  // Instantiates selected plant at argument position
                    position_to_spawn, transform.rotation);                             
                currentlyPlacedPlants.Add(position_to_spawn);                           // Adds plant transform to array
                plantWait = placedPlantWait;                                            // Sets our plantWait variable to intended wait
                StartCoroutine(CountdownTheTimer());                                    // Starts the timer countdown
            }
        }
    } // End of Function

    private void Update()
    {
        countdownScript.UpdateTimer(plantWait);   // Updates the timer every frame
    } // End of Function

    private bool IsPlantInCell(Vector3 position_to_spawn)
    {
        if (currentlyPlacedPlants.Count != 0)
        {                                                
            foreach (Vector3 position in currentlyPlacedPlants)  // Loops through array of Vector 3 positions
            {
                if (position == position_to_spawn)
                {
                    return true;    // If plant was already placed in array return true
                }
            }
            return false;   // Otherwise return false
        }
        return false;       // If array is empty return false                                     
    } // End of Function

    public void OnEnable()
    {
        packetPlacerScript = packetPlacerObject.GetComponent<PacketPlacer>(); // Sets up packet script for use
        countdownScript = countdownTimer.GetComponent<CountdownTimer>();      // Sets up countdown script for use
        StartCoroutine(ObserveAfterDelay());                                  // begins co-routine on enable
    } // End of Function

    public void OnDisable()
    {
        foreach (Cell cell in cells)                       // Loops through the cells array
        {
            cell.CellEvent.RemoveListener(SpawnPlayer);    // Removes listener from cell
        }
    } // End of Function

    private IEnumerator ObserveAfterDelay()                                      
    {
        yield return null;                                       // Skips 1 frame to let the cells initialize in LevelManager
        GameObject cellsGO = GameObject.Find("CellsPrefab");     // Finds the original cell object
        cells = cellsGO.GetComponentsInChildren<Cell>();         // Find all the Cell script components in the original cells children
        foreach (Cell cell in cells)                             // Loops through the cells array
        {
            cell.CellEvent.AddListener(SpawnPlayer);             // Adds a listener to each Cell script component
        }
    } // End of Function

    private IEnumerator CountdownTheTimer()
    {
        for (int x = 0; x < placedPlantWait; x++) // Loops for how many seconds the timer is set for
        {
            yield return new WaitForSeconds(1);   // Waits for one second
            plantWait -= 1;                       // Decrements the timer by 1
        }
    } // End of Function
} // End of Class
