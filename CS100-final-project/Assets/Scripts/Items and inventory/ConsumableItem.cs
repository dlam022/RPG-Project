using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable Item", fileName = "Consumable Item")]
public class ConsumableItem : Item
{
    [SerializeField]
    private int HealAmount;

    public int GetHealAmount()
    {
        return HealAmount;
    }
}
