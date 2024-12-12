using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    // All class variables
    
    [SerializeField] public float myHealth;           // Amount of total health for attached object
    [SerializeField] private GameObject deathVFX;     // GO for VFX
    [SerializeField] private float deathVFXLength;    // Length of objects death VFX in seconds
    public UnityEvent HealthEvent;


    // Beginning of Class Functions
    public void Damage(float damage)
    {
        myHealth -= damage;      // Reduces health of object by inputted number
        if (myHealth <= 0)       // If health of object reaches 0
        {
            if (gameObject.tag == "Friendlies")
            {
                HealthEvent.Invoke();
            }
            Death();             // Call death function to destroy object and play death VFX
            
        }
        
    } // End of Function

    private void Death()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);  // Instantiates the deathVFX prefab at the objects location
        Destroy(deathVFXObject, deathVFXLength);                                                    // Destroys the deathVFX object after specified time
        Destroy(gameObject);                                                                        // Destroys the object

    } // End of Function
} // End of Class
