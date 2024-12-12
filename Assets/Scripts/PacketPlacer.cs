using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacketPlacer : MonoBehaviour
{
    // All class variables 

    [SerializeField] private Sprite[] packetSprites;        // Array of sprites for packets
    [SerializeField] private GameObject[] plantPrefabs;     // Array of plant game objects
    [SerializeField] private GameObject packetPrefab;       // Packet prefab reference
    [SerializeField] private float packetXValue;            // First placed packets x value
    [SerializeField] private float packetYValue;            // First placed packets y value
    [SerializeField] private float packetZValue;            // First placed packets z value
    [SerializeField] private float packetSpacing;           // Space between placed packets
    private PacketSelector packetScript;            // Reference to the individual packets scripts
    public GameObject currentlySelectedPlant;       // public variable stating the selected plant


    // Beginning of class functions
    private void OnEnable()
    {
        for (int index = 0; index < packetSprites.Length; index++)                                                       // For each index in packetSprites 
        {
            Vector3 packetPlacement = new Vector3(packetXValue + (packetSpacing * index), packetYValue, packetZValue);   // Create new vector 3 for placement
            GameObject placedPacket = Instantiate(packetPrefab, packetPlacement, transform.rotation);                    // instantiate packet prefab at the vector3
            packetScript = placedPacket.GetComponent<PacketSelector>();                                                  // Get the script component of instantiated packet 
            packetScript.PacketEvent.AddListener(packetListener);                                                        // Add listener to script component
            packetPrefab.GetComponent<SpriteRenderer>().sprite = packetSprites[index];                                   // Get the sprite renderer component and set the sprite on it
            packetScript.indexNumber = index;                                                                            // set public variable index to store current index value on object
        }
    } // End of Function

    private void packetListener(int selectedIndex)
    {
        currentlySelectedPlant = plantPrefabs[selectedIndex];  // Set selected plant using stored index value
        Debug.Log(currentlySelectedPlant);                     // Debugs the selected plant
    } // End of Function

    private void OnDisable()
    {
        packetScript.PacketEvent.RemoveListener(packetListener); // Remove listener from packet object
    } // End of Function
} // End of Class
