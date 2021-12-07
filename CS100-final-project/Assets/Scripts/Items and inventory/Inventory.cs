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
        if(Weapon == item)
        {
            Weapon = null;
        }
        else
        {
            Weapon = item;
        }
        
    }

    public void EquipArmor(ArmorItem item)
    {
        switch (item.slot)
        {
            case ArmorItem.Slot.Chest:
                if(Chest == item)
                {
                    Chest = null;
                }
                else
                {
                    Chest = item;
                }
                break;
            case ArmorItem.Slot.Legs:
                if(Legs == item)
                {
                    Legs = null;
                }
                else
                {
                    Legs = item;
                }
                break;

            case ArmorItem.Slot.Head:
                if(Helmet == item)
                {
                    Helmet = null;
                }
                else
                {
                    Helmet = item;
                }
                break;
        }

    }

    /// <summary>
    /// Gets the cumulative value of equipped armor
    /// </summary>
    /// <returns></returns>
    public int GetArmorRating()
    {
        int rating = 0;
        if(Chest != null)
        {
            rating += Chest.GetArmorValue();
        }
        if(Legs!= null)
        {
            rating += Legs.GetArmorValue();
        }
        if(Helmet != null)
        {
            rating += Helmet.GetArmorValue();
        }

        return rating;
    }
    /// <summary>
    /// Gets the Attack value of the equipped weapon. If no weapon is equipped, returns 0.
    /// </summary>
    /// <returns></returns>
    public int GetAttackRating()
    {
        
        if(Weapon!= null)
        {
            return Weapon.GetAttackValue();
        }
        else
        {
            return 0;
        }
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

    public List<ArmorItem> GetEquippedArmor()
    {
        List<ArmorItem> armors = new List<ArmorItem>();

        if(Helmet != null)
        {
            armors.Add(Helmet);
        }
        if(Chest != null)
        {
            armors.Add(Chest);
        }
        if(Legs != null)
        {
            armors.Add(Legs);
        }
        
        return armors;
    }

    public WeaponItem GetEquippedWeapon()
    {
        if(Weapon != null)
        {
            return Weapon;
        }
        else
        {
            return null;
        }
    }
}
