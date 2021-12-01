using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base class that usable and equipable items will derive from
/// </summary>
/// 
//menuName is the name that shows when you right click to create a new
//asset in our files. You can use '/' to make subdirectories.
//Filename is the default name of the asset when created
[CreateAssetMenu(menuName = "Items/Item", fileName = "Item")]
public abstract class Item : ScriptableObject
{
    public Sprite ItemImage;

    //The name of the item
    [SerializeField]
    protected string itemName;

    //Serialize field makes the variable visible in and editable via the editor
    [SerializeField]
    [TextArea]
    //This string will be displayed in the menu and give information about what the item does
    protected string itemDescription;

    //Scriptable objects do not inherit from monobehavior and as such do not contain start or update methods.
    //They have been removed.

    public string GetDescription()
    {
        return itemDescription;
    }

    public string GetName()
    {
        return itemName;
    }

    public abstract void UseItem(CharacterSheet target);

}
