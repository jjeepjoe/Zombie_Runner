using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int currentWeapon = 0;

    //ON START WITH THIS WEAPON.
    private void Start()
    {
        SetWeaponActive();
    }
    //DO THE WORK KEYBOARD OR SCROLL WHEEL.
    private void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();
        //THERE IS CHANGE TO THE WEAPON
        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }
    //
    private void ProcessScrollWheel()
    {
        //SCROLL UP
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //WHEN AT THE END OF LIST TURN BACK TO START.
            if(currentWeapon >= transform.childCount -1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        //SCROLL DOWN
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //WHEN AT THE START OF LIST TURN BACK TO END.
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }
    //
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
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
