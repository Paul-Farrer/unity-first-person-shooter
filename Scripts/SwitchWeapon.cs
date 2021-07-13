using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{

    [SerializeField] private int currentActiveWeapon = 0;

    // Start is called before the first frame update
    private void Start()
    {
        SetActiveWeapon();
    }

    // Update is called once per frame
    private void Update()
    {
        int previousWeapon = currentActiveWeapon;

        ProcessInput();
        ProcessScrollWheel();

        if (previousWeapon != currentActiveWeapon) // if previous weapon is not equal to current weapon call the SetActiveWeapon method;
        {
            SetActiveWeapon();
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentActiveWeapon >= transform.childCount - 1) // e.g. if at maximum set currentActiveWeapon back to 0
            {
                currentActiveWeapon = 0;
            }
            else
            {
                currentActiveWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // inverted from the one above
        {
            if (currentActiveWeapon <= 0)
            {
                currentActiveWeapon = transform.childCount - 1;
            }
            else
            {
                currentActiveWeapon--;
            }
        }
    }

    private void ProcessInput()
    {
        // switch to weapon depending upon the number pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentActiveWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentActiveWeapon = 1;
        }
    }

    private void SetActiveWeapon()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform) // goes through all of the weapons in the transform weapon
        {
            if (weaponIndex == currentActiveWeapon) // if the weaponIndex is equal to the currentActiveWeapon the weapon will be set active
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
