using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomOutFOV= 60f;
    bool isZoomed = false;
    //CASHE
    Camera fpCamera;

    //COMPONENT CONECTION
    private void Start()
    {
        fpCamera = Camera.main;
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
    }
    //
    private void ZoomOut()
    {
        fpCamera.fieldOfView = zoomOutFOV;
    }
}
