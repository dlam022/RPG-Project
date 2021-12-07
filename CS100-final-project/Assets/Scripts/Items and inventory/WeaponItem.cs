using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Weapon Item", fileName = "Weapon Item")]
public class WeaponItem : Item
{
    [SerializeField]
    private int AttackValue;

    public int GetAttackValue()
    {
        return AttackValue;
    }

  
}
