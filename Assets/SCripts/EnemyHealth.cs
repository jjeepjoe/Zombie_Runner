using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float hitPoints = 100f;

    //public method to reduce points by damage
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log("HIT " + hitPoints);
        if(hitPoints <= 0)
        {
            FindObjectOfType<EnemySpawner>().SetAlive(); //Rosemarie game
            Destroy(gameObject);
        }
    }
}
