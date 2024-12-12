using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{
    // All class variables

    [SerializeField] private float peaDamage;   // Damage the pea should do on hit
    [SerializeField] private float peaSpeed;    // How fast the pea should travel


    // Beginning of class functions
    private void Update()
    {
        float trueSpeed = peaSpeed * Time.deltaTime;                                                    // Calculate the "true speed" of the object using Time.deltatime

        transform.position = new Vector3(transform.position.x + trueSpeed, transform.position.y, 0);    // Move object by true speed calculation each frame
    } // End of Function

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemies")                                   // If collided with object is an enemy
        {
            Health healthHandler = collision.GetComponent<Health>();      // Get health script handler of collided with object
            healthHandler.Damage(peaDamage);                              // Damage health of collided object
            Destroy(gameObject);                                          // Destroy the pea
        }
    } // End of Function
} // End of class
