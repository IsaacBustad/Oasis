using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // current health of character
    [SerializeField] private float currentHealth = 100f;

    // reduce health or take damage
    public void ReduceHealth(float dammage)
    {
        currentHealth -= dammage;

        if(currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    
}
