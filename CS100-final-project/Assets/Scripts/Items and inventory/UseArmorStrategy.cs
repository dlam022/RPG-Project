using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseArmorStrategy : UseItemStrategy
{

    public UseArmorStrategy(CharacterSheet sheet, ArmorItem item)
    {
        this.characterSheet = sheet;
        this.item = item;
    }


    public override void Execute()
    {
        characterSheet.inventory.EquipArmor(item as ArmorItem);
    }
}
