using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemViewer : MonoBehaviour
{
    public Image itemDisplayImage;
    public TMP_Text itemDescription;
    public UseItemButton button;

    public void Setup(CharacterSheet sheet, Item item, InventoryMenu menu) //Add the inventory list viewer class here to be passed, add a method as listener to use item button event
    {
        EvaluateContext(sheet, item);

        if(item.ItemImage != null)
        {
            itemDisplayImage.sprite = item.ItemImage;
        }
        
        itemDescription.text = item.GetDescription();

        button.Setup(item, EvaluateContext(sheet, item), menu);
    }

    public UseItemStrategy EvaluateContext(CharacterSheet sheet, Item item)
    {
        UseItemStrategy strategy;

        if (item as WeaponItem != null)
        {
            WeaponItem weapon = item as WeaponItem;
            strategy = new UseWeaponStrategy(sheet, weapon);
        }
        else if (item as ConsumableItem != null)
        {
            ConsumableItem consumable = item as ConsumableItem;
            strategy = new UseConsumableStrategy(sheet, consumable);
        }
        else //It can only be armor in this case
        {
            ArmorItem armor = item as ArmorItem;
            strategy = new UseArmorStrategy(sheet, armor);
        }

        return strategy;
    }

    


    public 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
