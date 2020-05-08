using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //CONFIG PARAMS >DATA HELPER CLASS IN THE INSPECTOR.
    [SerializeField] AmmoSlot[] ammoSlots;

    //INTERNAL HELPER DATA CLASS > 
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    //CAN SHOOT?
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    //SHOOTING
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount -= 1;
    }
    //PICKUPS
    public void IncreaseAmmoAmount(AmmoType ammoType, int amount)
    {
        GetAmmoSlot(ammoType).ammoAmount += amount;
    }
    //HELPER METHOD > FIND THE SLOT TO MATCH THE WEAPON.
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
