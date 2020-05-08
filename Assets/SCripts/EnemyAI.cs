using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //CONFIG PARAMS
    Transform target;
    [SerializeField] float chaseRange = 10f;
    float distanceToTarget = Mathf.Infinity; //STARTING DISTANCE RETURN.
    [SerializeField] float turnSpeed = 5f;

    //CASHE COMPONENT/ OBJECT STATE
    NavMeshAgent navMeshAgent;
    Animator myAnimator;
    EnemyHealth myHealth;
    bool isProvoked = false;

    //MAKE COMPONENTE CONNECTIONS
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        myHealth = GetComponent<EnemyHealth>();
        target = GameObject.Find("Player").transform;
    }
    //LIVING ZOMBIE ACTIONS
    private void Update()
    {
        //USED TO STOP THE DEAD
        if (myHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        //DETECTION RANGE (IT, ME), IN FLOAT RETURN.
        distanceToTarget = Vector3.Distance(target.position,
                                    transform.position);
        //THE FLAG isProvoked CAN BE TRIGGERED BY OTHER ACTIONS/ AND RANGE.
        if (isProvoked)
        {
            ProvokedActions();
            FaceTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;            
        }
    }
    //ZOMBIE GOT SHOT
    public void OnDamageTaken()
    {
        isProvoked = true;
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
        navMeshAgent.SetDestination(target.position);
    }
    //VISUAL RANGE IN EDITOR VIEW/ LINE FOR LINE MATCH.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    //WHEN IN ATTACK RANGE WE NEED TO FACE CORRECTLY.
    private void FaceTarget()
    {
        //NORMALIZED REMOVES SOME OF THE MATH WE DO NOT NEED FOR OUR CALCULATION
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(
                                    direction.x, 0, direction.z));
        //SLERP =  A QUATERNION METHOD OF ROTATION CHANGE
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,
                                    Time.deltaTime * turnSpeed);
    }
}
