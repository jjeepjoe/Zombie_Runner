using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    //public method to reduce points by damage
    public void TakeDamage(float damage)
    {
        //THIS WILL CALL FOR THIS METHOD ON THE GAMEOBJECT CONTAINER.
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        Debug.Log("[EnemyHealth.cs]:: I HIT THE ZOMBIE " + hitPoints);
        if(hitPoints <= 0)
        {
            //FindObjectOfType<EnemySpawner>().SetAlive(); //Rosemarie game
            //Destroy(gameObject);
            //UPDATED TO NEW ANIMATION PLUS KEEP BODY AROUND.
            if(isDead) { return; }
            isDead = true;
            GetComponent<Animator>().SetTrigger("Death");
        }
    }
}
