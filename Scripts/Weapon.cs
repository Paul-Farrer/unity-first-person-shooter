using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f; // defines the range of the raycast. May want to alter it depending upon the weapon
    [SerializeField] private float damage = 50f;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Ammunition ammunitionSlot;
    [SerializeField] private AmmunitionType ammunitionType;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float timeBetweenShots = 1f;
    [SerializeField] private TextMeshProUGUI ammunitionText;
    [SerializeField] private AudioClip shootingSound;
    private AudioSource audioSource;
    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        DisplayAmmunitionHUD();

        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmunitionHUD()
    {
        int currentAmmunition = ammunitionSlot.GetCurrentAmmo(ammunitionType);
        ammunitionText.text = currentAmmunition.ToString();
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammunitionSlot.GetCurrentAmmo(ammunitionType) > 0)
        {
            PlayShootAudio();
            PlayMuzzleFlash();
            ProcessRaycast();
            ammunitionSlot.ReduceCurrentAmmo(ammunitionType);
        }
        yield return new WaitForSeconds(timeBetweenShots); // adds a delay between shots 
        canShoot = true;
    }

    private void PlayShootAudio()
    {
        audioSource.PlayOneShot(shootingSound);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
        Invoke("StopMuzzleFlash", 0.1f);
    }

    void StopMuzzleFlash()
    {
        muzzleFlash.Stop();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        // if raycast hits enemy it will reduce their health by calling the ReceiveDamage function passing the argument damage
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.ReceiveDamage(damage);
        }
        else
        {
            return;
        }


    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // instantiate hitEffecct at the location where impacted with it facing away from the target hit
        Destroy(impact, 1);
    }
}
