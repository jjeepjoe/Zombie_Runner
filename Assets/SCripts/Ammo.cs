using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //CONFIG PARAMs
    [SerializeField] int ammoAmount = 10;

    //
    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }
    //
    public void ReduceCurrentAmmo()
    {
        ammoAmount -= 1;
    }
    //
    public void SetAmmoAmount(int amount)
    {
        ammoAmount += amount;
    }
}
