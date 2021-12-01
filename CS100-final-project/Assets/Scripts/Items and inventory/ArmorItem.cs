using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Armor Item", fileName = "Armor Item")]
public class ArmorItem : Item
{
    [SerializeField]
    private int armorValue;

    public enum Slot {Head, Chest, Legs};

    [SerializeField]
    public Slot slot;

    public int GetArmorValue()
    {
        return armorValue;
    }

    // Start is called before the first frame update
    public override void UseItem(CharacterSheet target)
    {
        target.inventory.EquipArmor(this);
        //throw new System.NotImplementedException();
    }
}
