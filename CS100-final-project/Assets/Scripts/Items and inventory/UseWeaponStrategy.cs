using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeaponStrategy : UseItemStrategy
{


    public UseWeaponStrategy(CharacterSheet sheet, WeaponItem item)
    {
        this.characterSheet = sheet;
        this.item = item;
    }


    protected override void Execute()
    {
        characterSheet.inventory.EquipWeapon(item as WeaponItem);
    }
}
