using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int amountAmmo = 5;
    [SerializeField] AmmoType ammoType;
    //
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("PICK ME UP!!");
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, amountAmmo);
            Destroy(gameObject);
        }
    }
}
