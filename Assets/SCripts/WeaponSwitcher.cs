using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    //
    [SerializeField] int currentWeapon = 0;

    private void Start()
    {
        SetWeaponActive();
    }
    //
    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        //THIS SCRIPT IS ON THE PARENT > WE ONLY HAVE WEAPONS AS CHILDREN
        //SO THEY ARE INDEXED FROM 0 > AND WE KNOW THEY HAVE A TRANSFORM COMPONENT.
        foreach(Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
