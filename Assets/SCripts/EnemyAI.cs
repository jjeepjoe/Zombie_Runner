using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //CONFIG PARAMS
    Transform targetTransform;
    [SerializeField] float chaseRange = 10f;
    float distanceToTarget = Mathf.Infinity; //STARTING DISTANCE RETURN.

    //CASHE COMPONENT/ OBJECT STATE
    NavMeshAgent navMeshAgent;
    Animator myAnimator;
    bool isProvoked = false;

    //MAKE CONNECTIONS
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        targetTransform = GameObject.Find("Player").transform;
    }
    //LIVE ACTIONS
    private void Update()
    {
        //DETECTION RANGE (IT, ME), IN FLOAT RETURN.
        distanceToTarget = Vector3.Distance(targetTransform.position,
                                    transform.position);
        //THE FLAG isProvoked CAN BE TRIGGERED BY OTHER ACTIONS/ AND RANGE.
        if (isProvoked)
        {
            ProvokedActions();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;            
        }
    }
    //PROVOKED ACTIONS.
    private void ProvokedActions()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AtttackTarget();
        }        
    }
    //
    private void AtttackTarget()
    {
        Debug.Log("CHOMP CHOMP CHEW");
        myAnimator.SetBool("Attack", true);
    }
    //FOLLOW THE PLAYER/ CAN LOOSE INTEREST ONCE OUT OF RANGE.
    private void ChaseTarget()
    {
        myAnimator.SetBool("Attack", false);
        myAnimator.SetTrigger("Move");
        navMeshAgent.SetDestination(targetTransform.position);
    }
    //VISUAL RANGE IN EDITOR VIEW/ LINE FOR LINE MATCH.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
