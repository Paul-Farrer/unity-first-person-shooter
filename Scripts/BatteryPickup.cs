using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] private float restoreAngle = 90f;
    [SerializeField] private float addFlashlightRange = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<Flashlight>().RestoreFlashlightAngle(restoreAngle);
            other.GetComponentInChildren<Flashlight>().addFlashlightRange(addFlashlightRange);
            Destroy(gameObject);
        }
    }

}
