using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    PlayerHealth playerHealth;

    //
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        
    }
    //ANIMATOR EVENT
    public void AttackHitEvent()
    {
        if (target == null) { return; }
        Debug.Log("PUNCH CHOMP PUNCH");
        //
        if (playerHealth != null) 
        {
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Debug.Log("NULL MOfo");
        }

    }
}
