using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //CONFIG PARAMS
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    //CONFIG COMPONENTS
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        
    }
    //ANIMATOR EVENT
    public void AttackHitEvent()
    {
        if (target == null) { return; }
        Debug.Log("PUNCH CHOMP PUNCH");
        //
        target.TakeDamage(damage);
    }
}
