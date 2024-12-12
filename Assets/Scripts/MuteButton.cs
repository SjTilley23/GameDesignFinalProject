using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    // All class variables

    private AudioSource audioSource;  // Empty reference variable for use later


    // Beginning of class functions
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Hooks up the reference variable to the AudioSource component on instantiation
    } // End of Function

    public void MuteButtonHandler()
    {
        audioSource.mute = !audioSource.mute;       // Flips mute bool on call of function
    } // End of Function
} // End of Class
