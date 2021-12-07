using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class ViewItemButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public InventoryMenu menu;
    public Item item;

    public Image buttonImage;
    public TMP_Text buttonText;



    public void Setup(InventoryMenu m, Item i)
    {
        item = i;
        menu = m;

        if(buttonImage == null)
        {
            buttonImage = GetComponentInChildren<Image>();
        }
        buttonImage.enabled = false;

        if(buttonText == null)
        {
            buttonText = gameObject.GetComponentInChildren<TMP_Text>();
        }
        buttonText.text = item.GetName();
        ModifyText(m, i);

    }

    private void ModifyText(InventoryMenu m, Item i)
    {
        if(i as WeaponItem != null)
        {
            WeaponItem weapon = i as WeaponItem;

            WeaponItem equippedWeapon = m.playerCharacterSheet.inventory.GetEquippedWeapon();
            if(equippedWeapon != null && equippedWeapon == weapon)
            {
                buttonText.text += " *";
            }
        }
        else if(i as ArmorItem != null)
        {
            ArmorItem armor = i as ArmorItem;

            List<ArmorItem> armors = m.playerCharacterSheet.inventory.GetEquippedArmor();

            if(armors.Contains(armor))
            {
                buttonText.text += " *";
            }
        }
        else
        {
            return;
        }
        
    }


    public void OnPointerEnter(PointerEventData data)
    {
        menu.MouseEnterButton(this);
    }

    public void OnPointerExit(PointerEventData data)
    {
        menu.MouseExitButton(this);
    }

    public void OnPointerClick(PointerEventData data)
    {
        menu.SelectButton(this);
        
    }
}
