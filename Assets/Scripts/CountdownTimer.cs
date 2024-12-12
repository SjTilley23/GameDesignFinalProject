using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // All class variables
    private Text countdownText;                       // Empty text component reference

    // Beginning of class functions
    private void Start()
    {
        countdownText = GetComponent<Text>();  // Get handle on text component
    } // End of Function

    public void UpdateTimer(float value)
    {
        countdownText.text = value.ToString(); // Set text component to argument
    } // End of Function
} // End of Class
