using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour
{

    [SerializeField] private int ammunitionSupplyAmount = 10;
    [SerializeField] private AmmunitionType ammunitionType;
    [SerializeField] private float rotation = 100f;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0); // rotate the pickup
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammunition>().IncreaseCurrentAmmo(ammunitionType, ammunitionSupplyAmount);
            Destroy(gameObject, 0f);
        }
    }


    // private void OnCollisionEnter(Collision other) {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         Debug.Log("Picked up");
    //     }
    // }
}
