using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{
    // local vars
    public bool isInSight = false;


    private void OnTriggerEnter(Collider otherObj)
    {
        if(otherObj.gameObject.layer == 7)
        {
            this.isInSight = true;
        }
    }


    private void OnTriggerExit(Collider otherObj)
    {
        if (otherObj.gameObject.layer == 7)
        {
            this.isInSight = false;
        }
    }
}
