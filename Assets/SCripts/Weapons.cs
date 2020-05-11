using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f; // weapon range
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float shootTimeDelay = 1f;
    [SerializeField] AmmoType ammoType;
    float fireTime = 0f;

    //CASHE
    [SerializeField] Ammo ammoSlot;
    [SerializeField] TextMeshProUGUI ammoText;

    //ADDED TO THE WEAPON SINCE ATTACHED TO PLAYER
    void Update()
    {
        DisplayAmmo();
        float currentTime = Time.time;
        if (Input.GetButtonDown("Fire1") && (currentTime > fireTime))
        {
            fireTime = currentTime + shootTimeDelay;
            Shoot();
        }
        //FOR ROSEMARIE TO PLAY.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    //WILL GET THE CURRENT AMMO USED AND DISPLAY THE AMOUNT.
    private void DisplayAmmo()
    {
        ammoText.text = "Ammo: " + ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }
    //
    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        else
        {
            Debug.Log("CLICK CLICK ALL OUT!");
        }
    }
    //
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    //
    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position,
                        FPCamera.transform.forward,
                        out hit, range
        ))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
    //WEAPON HITS
    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject temp_GO = Instantiate(hitEffect, hit.point, 
                                Quaternion.LookRotation(hit.normal));
        Destroy(temp_GO, .1f);
    }
}
