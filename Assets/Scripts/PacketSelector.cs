using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PacketSelector : MonoBehaviour
{
    // All class variables

    public UnityEvent<int> PacketEvent;    // Event that allows int to be passed
    public int indexNumber;                // public int for storing index value


    // Beginning of class functions
    private void OnMouseDown()
    {
        PacketEvent.Invoke(indexNumber);   // Invokes listener and passes index value
    } // End of Function
} // End of Class
