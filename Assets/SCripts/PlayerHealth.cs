using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float playerHitPoints = 100f;

    //
    public void TakeDamage(float damage)
    {
        playerHitPoints -= damage;
        Debug.Log("ZOMBIE HIT ME " + playerHitPoints);
        if (playerHitPoints <= 0)
        {
            Debug.Log("DEAD DEAD DEAD");
        }
    }
}
