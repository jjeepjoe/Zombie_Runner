using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomOutFOV= 60f;
    [SerializeField] float zoomInSensitivity = .5f;
    [SerializeField] float zoomOutSensitivity = 2f;
    bool isZoomed = false;
    //CASHE
    Camera fpCamera;
    RigidbodyFirstPersonController fpsControl;

    //COMPONENT CONECTION
    private void Start()
    {
        fpCamera = Camera.main;
        fpsControl = GetComponentInParent<RigidbodyFirstPersonController>();
    }
    //USER INPUT > CLICK DOWN = ZOOM > RELEASE THE BUTTON = UNZOOM
    private void Update()
    {
        //TOGGLE BUTTON USE INTERNAL ZOOM
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoomed)
            {
                isZoomed = true;
                ZoomIn();
            }
            else
            {
                isZoomed = false;
                ZoomOut();
            }            
        }
        //BUTTON HOLD FOR ZOOM
        //else if(Input.GetMouseButtonUp(1))
        //{
        //    ZoomOut();
        //}
    }
    //
    private void ZoomIn()
    {
        fpCamera.fieldOfView = zoomInFOV;
        fpsControl.mouseLook.XSensitivity = zoomInSensitivity;
        fpsControl.mouseLook.YSensitivity = zoomInSensitivity;
    }
    //
    private void ZoomOut()
    {
        fpCamera.fieldOfView = zoomOutFOV;
        fpsControl.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsControl.mouseLook.YSensitivity = zoomOutSensitivity;
    }
    //WHEN DISABLED THIS IS CALLED FOR CLEAN UP
    private void OnDisable()
    {
        ZoomOut();   
    }
}
