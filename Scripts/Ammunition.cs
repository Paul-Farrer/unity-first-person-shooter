using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private AmmunitionSlot[] ammunitionSlots; // allows specified number of slots to be created (multiple types of ammunition e.g. rockets, bullets and shells). Presemts the bits of information within the AmmunitionSlot class

    [System.Serializable] // shows the content of AmmunitionSlot within the inspector
    private class AmmunitionSlot
    {
        public AmmunitionType ammunitionType; // select the ammunition type within the inspector
        public int ammunitionAmount; // specify the ammunition ammount for the weapon
    }

    public int GetCurrentAmmo(AmmunitionType ammunitionType)
    {

        return GetAmmunitionSlot(ammunitionType).ammunitionAmount;
    }

    public void ReduceCurrentAmmo(AmmunitionType ammunitionType)
    {
        GetAmmunitionSlot(ammunitionType).ammunitionAmount--;
    }

    public void IncreaseCurrentAmmo(AmmunitionType ammunitionType, int ammunitionSupplyAmount)
    {
        GetAmmunitionSlot(ammunitionType).ammunitionAmount += ammunitionSupplyAmount;
    }

    private AmmunitionSlot GetAmmunitionSlot(AmmunitionType ammunitionType)
    {
        foreach (AmmunitionSlot ammunitionSlot in ammunitionSlots)
        {
            if (ammunitionSlot.ammunitionType == ammunitionType) // if the ammunitionType within AmmunitionSlot is equal to the ammunitionType passed into the argument return the ammunitionSlot
            {
                return ammunitionSlot;
            }
        }
        return null;
    }


}
