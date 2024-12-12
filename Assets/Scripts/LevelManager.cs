using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // All class variables

    [SerializeField] private GameObject cellObject;      // Inspector variable for cell object reference
    [SerializeField] private GameObject cellPrefab;      // Inspector variable for cell prefab reference
    [SerializeField] private int numberOfRows;           // Number of rows in play
    [SerializeField] private int numberOfColumns;        // Number of columns in play

    // Beginning of class functions
    private void Start()
    {
        for (int x = 1; x <= numberOfColumns; x++)                                     // Increments through the "columns" of the map
        {
            for (int y = 1; y <= numberOfRows; y++)                                    // Increments through the "rows" of the map
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3((2 * x) - 1,     // Instantiates a new cell at a unique column/row number
                    (2 * y) - 1, 0), Quaternion.identity, cellObject.transform);
                Debug.Log(cell.transform.position);                                    // Debugs the just instantiated cell's transform position
            }
        }
    } // End of Function
} // End of Class
