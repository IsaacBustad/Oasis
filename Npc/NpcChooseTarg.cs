using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcChooseTarg : MonoBehaviour
{
    // local vars
    // set array in inspector to layer count andmake proority levels for each layer
    public int[] targAndValues;
    public NpcLineOfSight fieldOfView;
    public GameObject currentTarg = null;
    public NpcAi npcAi;
    

    private void Awake()
    {
        this.fieldOfView = gameObject.GetComponent<NpcLineOfSight>();
        this.npcAi = gameObject.GetComponentInParent<NpcAi>();

        
    }

    // choose target
    public void ChooseTarg()
    {
        foreach (GameObject obj in this.fieldOfView.objsInSight)
        {
            if (this.currentTarg == null)
            {
                this.currentTarg = obj;
                Debug.Log(this.currentTarg.layer);
            }

            else if (this.targAndValues[obj.layer] < this.targAndValues[currentTarg.layer])
            {
                this.currentTarg = obj;
            }
        }
        this.npcAi.target = this.currentTarg.transform;
    }

}
