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
<<<<<<< HEAD
        playerHealth = FindObjectOfType<PlayerHealth>();        
=======
        target = FindObjectOfType<PlayerHealth>();
        
>>>>>>> ba8ef8b2b38840c7c34e1f252ad372839376851b
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
