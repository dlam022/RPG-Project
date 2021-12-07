using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    [SerializeField]
    private int HealAmount;

    public int GetHealAmount()
    {
        return HealAmount;
    }
}
