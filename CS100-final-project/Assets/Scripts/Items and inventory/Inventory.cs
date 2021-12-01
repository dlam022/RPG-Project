using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//In order to override a unity event (basically a safe and editor friendly delegate)
//You must inherit from the class and define a new event type. No further 
//action is required.
[System.Serializable]
public class ItemEvent : UnityEvent<Item> { };


[System.Serializable]
public class Inventory 
{
    public ItemEvent OnAddItem;
    public ItemEvent OnRemoveItem;

    [SerializeField]
    private List<Item> itemsInInventory;

    private ArmorItem Chest;
    private ArmorItem Legs;
    private ArmorItem Helmet;

    private WeaponItem Weapon;

    public void EquipWeapon(WeaponItem item)
    {
        Weapon = item;
    }

    public void EquipArmor(ArmorItem item)
    {
        switch (item.slot)
        {
            case ArmorItem.Slot.Chest:
                Chest = item;
                break;
            case ArmorItem.Slot.Legs:
                Legs = item;
                break;

            case ArmorItem.Slot.Head:
                Helmet = item;
                break;
        }


    }

    /// <summary>
    /// Gets the cumulative value of equipped armor
    /// </summary>
    /// <returns></returns>
    public int GetArmorRating()
    {
        return Chest.GetArmorValue() + Legs.GetArmorValue() + Helmet.GetArmorValue();
    }

    public void AddItemToInventory(Item item)
    {
        if(itemsInInventory == null)
        {
            itemsInInventory = new List<Item>();
        }

        itemsInInventory.Add(item);

        if (OnAddItem != null)
        {
            OnAddItem.Invoke(item);
        }
    }

    public void RemoveItemFromInventory(Item item)
    {
        if (itemsInInventory == null)
        {
            itemsInInventory = new List<Item>();
        }

        if(itemsInInventory.Contains(item))
        {
            itemsInInventory.Remove(item);
        }


        if(OnRemoveItem != null)
        {
            OnRemoveItem.Invoke(item);
        }
    }

    /// <summary>
    /// Returns the list of items in inventory.
    /// </summary>
    /// <returns></returns>
    public List<Item> GetItemsInInventory()
    {
        return itemsInInventory;
    }
}
