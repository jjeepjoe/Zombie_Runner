﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //CONFIG PARAMS
    PlayerHealth targetPlayer;
    [SerializeField] float damage = 40f;

    //CONFIG COMPONENTS
    private void Start()
    {
        targetPlayer = FindObjectOfType<PlayerHealth>();
    }
    //ANIMATOR EVENT
    public void AttackHitEvent()
    {
        Debug.Log("[EnemyAttack.AttackHitEvent()]:: PUNCH CHOMP PUNCH");
        if (targetPlayer == null) { return; }        
        //USING 1 COMPONENT TO DO TWO THINGS
        targetPlayer.TakeDamage(damage);
    }
    //TESTING BROADCAST MESSAGE
    public void OnDamageTaken()
    {
        Debug.Log("[EnemyAttack.OnDamageTaken()]:: UGG, ME EAT YOU NOW!");
    }
}
