using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }
    //
    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }
    //
    private void DecreaseLightIntensity()
    {
        myLight.intensity -= (Time.deltaTime * lightDecay);
    }
    //
    private void DecreaseLightAngle()
    {
        if(myLight.spotAngle <= minimumAngle)
        { 
            return; 
        }
        else
        {
            myLight.spotAngle -= (Time.deltaTime * angleDecay);
        }
    }
}
