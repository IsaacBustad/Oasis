using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLineOfSight : MonoBehaviour
{
    // local vars
    public bool isInSight = false;
    public int[] spotableObjects;
    public List<GameObject> objsInSight;
    public NpcChooseTarg npcChooseTarg;
    public BoxCollider viewTrig;

    private void Awake()
    {
        this.npcChooseTarg = gameObject.GetComponent<NpcChooseTarg>();

        this.viewTrig = gameObject.GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider otherObj)
    {
        
        this.isInSight = true;
        this.objsInSight.Add(otherObj.gameObject);
        this.npcChooseTarg.ChooseTarg();
        
    }


    private void OnTriggerExit(Collider otherObj)
    {
        int layInt = otherObj.gameObject.layer;
        if (Array.Exists(spotableObjects, element => element == layInt))
        {
            this.isInSight = false;
            this.objsInSight.Remove(otherObj.gameObject);

        }
    }
}
