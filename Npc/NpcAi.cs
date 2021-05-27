using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAi : MonoBehaviour
{
    // player and enemy info
    public Transform target;
    NavMeshAgent navMeshAgent;
    private NpcLineOfSight fieldOfView;


    // set decision making for enemies
    [SerializeField] private float chaseRange;
    private float distanceToTarget = Mathf.Infinity;

    // public vars
    private bool isProvoked = false;

    // awake called before start
    private void Awake()
    {
        //this.target = GameObject.Find("MyPlayer").transform;
        this.navMeshAgent = GetComponent<NavMeshAgent>();

        fieldOfView = gameObject.GetComponentInChildren<NpcLineOfSight>();
    }



    // Update is called once per frame
    void Update()
    {
        if (this.target != null)
        {
            this.distanceToTarget = Vector3.Distance(this.target.position, this.transform.position);

            if (isProvoked == true)
            {
                EngageTarget();
            }

            else if (this.distanceToTarget <= this.chaseRange && this.fieldOfView.isInSight == true)
            {
                this.isProvoked = true;
            }
        }
                
    }


    // Engage or interact with target
    private void EngageTarget()
    {
        if (this.distanceToTarget > this.navMeshAgent.stoppingDistance)
        {
            if (this.distanceToTarget > this.chaseRange && this.fieldOfView.isInSight == false)
            {
                this.isProvoked = false;
            }
            else
            {
                ChaseTarget();
            }
        }

        else if (this.distanceToTarget <= this.navMeshAgent.stoppingDistance)
        {
            Attack();
        }

        
    }

    // chase target
    private void ChaseTarget()
    {        
        this.navMeshAgent.SetDestination(target.position);
    }

    // attack target
    private void Attack()
    {
        Debug.Log("Atacking " + this.target.name);
    }

    



}
