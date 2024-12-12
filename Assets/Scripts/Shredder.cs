using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Beginning of class functions
    private void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);                   // Destroys game object collided with
    } // End of Function
} // End of Class
