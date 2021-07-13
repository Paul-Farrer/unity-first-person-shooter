using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private float flashlightRangeDecay = 0f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minimumAngle = 40f;

    private Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseFlashlightRange();
        DecreaseFlashlightAngle();
    }

    public void RestoreFlashlightAngle(float restoreFlashlightAngle)
    {
        flashlight.spotAngle = restoreFlashlightAngle;
    }

    public void addFlashlightRange(float flashlightRangeAmount)
    {
        flashlight.range += flashlightRangeAmount;
    }

    private void DecreaseFlashlightRange()
    {
        flashlight.range -= flashlightRangeDecay; // reduce the flashlight intensity overtime
    }

    private void DecreaseFlashlightAngle() // makes the flashlight angle narrower overtime but stops at the minimum angle value
    {
        if (flashlight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            flashlight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
}
