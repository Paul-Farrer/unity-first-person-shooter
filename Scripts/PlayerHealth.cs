using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    [SerializeField] private AudioClip injured;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(injured);
        }

        if (health <= 0)
        {
            // Destroy(gameObject, 0f);
            GetComponent<DeathHandler>().HandleDeath();
        }

    }


}
