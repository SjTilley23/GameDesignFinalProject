using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // All class variables both inspector and non-inspector

    [SerializeField] private float ZombieSpeed;            // How many world units per second the zombie moves
    [SerializeField] private float ZombieDamage;           // How much damage the zombie does per "chomp"
    [SerializeField] private float SecondsBetweenBites;    // How many seconds to wait in between bites
    private Animator animator;                             // Empty variable for animator component
    private Health healthHandler;                          // Empty Health variable for setup later
    private bool currentlyEating = false;                  // Zombie starts off spawn not eating and insterad moving

    // Beginning of class functions
    private void Start()
    {
        animator = GetComponent<Animator>();               // gets reference to animator component
    } // End of Function

    // Beginning of all class Functions
    private void Update()
    {
        if (currentlyEating == false)                                                    // If zombie is not eating then proceed
        {
            StopAllCoroutines();
            float trueSpeed = ZombieSpeed * Time.deltaTime;                              // Determines the "TrueSpeed" of the zombie using Time.deltatime
            gameObject.transform.position = new Vector3(gameObject.transform.position.x  // Changes transform position of zombie to make it move. Keeps y and z the same,
                - trueSpeed, gameObject.transform.position.y, 0);                        // changes x value by trueSpeed. Keeps y and z the same changes x value by trueSpeed.
        }
    } // End of Function

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Friendlies")            // Checks if collided with object is a friendly unit
        {
            healthHandler = collision.GetComponent<Health>();    // Sets up script handler for use
            healthHandler.HealthEvent.AddListener(ResumeWalking);// Calls the Resume walking coroutine
            StartCoroutine(WaitForBite());                       // Start the Wait for Bite coroutine
            animator.SetBool("IsEating", true);                  // Sets bool for animations
            currentlyEating = true;                              // Sets currently eating to true to stop zombie movement
        } 
    } // End of Function

    private IEnumerator WaitForBite()
    {
        while (true) // While collided with object still has health
        {
            yield return new WaitForSeconds(SecondsBetweenBites); // Wait for x seconds between bites
            healthHandler.Damage(ZombieDamage);
        }
    } // End of Function

    private void ResumeWalking()
    {
        StopCoroutine(WaitForBite());          // Stops the Wait for bite coroutine so zombie does not eat air
        currentlyEating = false;               // sets currently eating to false so zombie walks again
        animator.SetBool("IsEating", false);   // sets is eating to false so zombie has correct animations
    } // End of Function
} // End of Class
