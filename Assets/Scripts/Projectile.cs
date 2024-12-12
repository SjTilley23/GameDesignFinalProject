using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // All class variables

    [SerializeField] private float minProjectileTime;        // Minimum time between shot projectiles
    [SerializeField] private float maxProjectileTime;        // Maximum time between shot projectiles
    [SerializeField] private GameObject projectilePrefab;    // Projectile prefab reference
    [SerializeField] private float projectileOffset;         // Vertical offset of projectile
    private Animator animator;                               // Empty animator reference

    // Beginning of class functions
    private IEnumerator WaitForProjectile()
    {
        while (true)            // Loop until object is destroyed
        {
            if (IsEnemyInLane())         // Check if enemy is in lane at the moment          
            {
                float projectileWait = Random.Range(minProjectileTime, maxProjectileTime);    // Determine a random time to using inspector variables
                yield return new WaitForSeconds(projectileWait);                              // Wait for specified time
                Vector3 PeaTransform = new Vector3(transform.position.x,                      // Creates a Vector 3 from the objects transform including the - 
                    transform.position.y + projectileOffset, 0);                              // pea offset for use when instantiating the pea
                Instantiate(projectilePrefab, PeaTransform, transform.rotation);              // Instantiate projectile at objects location
            }
            else
            {
                yield return new WaitForSeconds((float).1);    // If enemy is not in lane wait .1 seconds before resuming
            }
        }
    } // End of Function

    private void Start()
    {
        animator = GetComponent<Animator>();  // Fill animator reference
        StartCoroutine(WaitForProjectile());  // Begin the projectile coroutine
    } // End of Function

    private bool IsEnemyInLane()
    {
        RaycastHit[] hits;                                          // empty array of raycast hits
        Ray ray = new Ray(transform.position, transform.right);     // create new ray from object going to the right
        hits = Physics.RaycastAll(ray);                             // fill array with all detected ray hits
        
        foreach (RaycastHit hit in hits)                            // loops through array of hits
        {
            if (hit.collider.gameObject.CompareTag("Enemies"))      // compare tag to see if object is an enemy
            {
                animator.SetBool("IsShooting" ,true); // Set IsShooting to true to transition to shooting animation
                return true;                          // return true if object is an enemy
            }
        }
        animator.SetBool("IsShooting", false);  // Set IsShooting to false to transition to idle animation
        return false;                           // return false otherwise
    } // End of Function
} // End of class
