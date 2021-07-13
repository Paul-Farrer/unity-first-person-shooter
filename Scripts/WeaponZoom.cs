using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera cameraFPS;
    [SerializeField] private RigidbodyFirstPersonController controllerFPS;
    [SerializeField] private float zoomedIn = 20f;
    [SerializeField] private float zoomedOut = 60f;
    [SerializeField] private float mouseSensitivityZoomedIn = 0.5f;
    [SerializeField] private float mouseSensitivityZoomedOut = 2f;

    private bool toggleFOVZoomedIn = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        if (toggleFOVZoomedIn == false)
            toggleFOVZoomedIn = true;
        cameraFPS.fieldOfView = zoomedIn; // sets the fov of the camera when zoomed in
        // alters the sensitivity of the mouse when zoomed in of both axis
        controllerFPS.mouseLook.XSensitivity = mouseSensitivityZoomedIn;
        controllerFPS.mouseLook.YSensitivity = mouseSensitivityZoomedIn;
    }

    private void ZoomOut()
    {
        toggleFOVZoomedIn = false;
        cameraFPS.fieldOfView = zoomedOut;
        controllerFPS.mouseLook.XSensitivity = mouseSensitivityZoomedOut;
        controllerFPS.mouseLook.YSensitivity = mouseSensitivityZoomedOut;
    }
}
