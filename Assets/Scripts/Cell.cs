using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    // All class variables

    public UnityEvent<Vector3> CellEvent;                  // Unity Event created and published


    // Beginning of class functions
    private void OnMouseDown()                             // When mouse is clicked inside cell's collider
    {
        CellEvent.Invoke(transform.position);              // Invokes all subscribers of CellEvent
        Debug.Log(gameObject.transform.position);          // Debugs the transform of clicked object
    } // End of Function
} // End of Class
