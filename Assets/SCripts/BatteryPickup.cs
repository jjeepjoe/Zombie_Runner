using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float restoreIntensity = 10f;
    [SerializeField] float restoreAngle = 70f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("BATTERY ON ME!");
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    }
}
