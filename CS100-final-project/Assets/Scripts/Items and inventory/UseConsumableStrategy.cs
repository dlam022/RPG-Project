using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseConsumableStrategy : UseItemStrategy
{
    public UseConsumableStrategy(CharacterSheet sheet, ConsumableItem item)
    {
        this.characterSheet = sheet;
        this.item = item;
    }


    public override void Execute()
    {
        ConsumableItem it = item as ConsumableItem;
        int amount = it.GetHealAmount();

        characterSheet.stats.ModifyCurrentHealth(amount);

        characterSheet.inventory.RemoveItemFromInventory(it);
    }
}
