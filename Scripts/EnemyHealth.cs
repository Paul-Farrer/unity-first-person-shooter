using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;
    [SerializeField] private float destroyTimer = 5f;

    public void ReceiveDamage(float weaponDamage)
    {

        BroadcastMessage("OnDamageTaken"); // calls method that is on the game object or its children 
        hitPoints -= weaponDamage;
        Debug.Log(hitPoints);
        if (hitPoints <= 0)
        {
            GetComponent<EnemyAI>().Dead();
            Destroy(gameObject, destroyTimer); 
        }

    }
}
