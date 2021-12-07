using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public CharacterSheet playerCharacterSheet;
    public GameObject gridLayoutObject;
    public GameObject ItemButtonPrefab;

    public ItemViewer viewer;

    public List<ViewItemButton> buttons;
    public ViewItemButton activeButton;

    public void ResetList()
    {
        activeButton = null;

        for(int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i].gameObject);
        }

        buttons.Clear();

        foreach(Item item in playerCharacterSheet.inventory.GetItemsInInventory())
        {
            if(item != null)
            {
                GameObject g = Instantiate(ItemButtonPrefab);
                g.transform.SetParent(gridLayoutObject.transform);
                ViewItemButton button = g.GetComponent<ViewItemButton>();

                g.SetActive(true);
                button.Setup(this, item);
            }
        }

    }

    public void SelectButton(ViewItemButton button)
    {
        button.buttonImage.enabled = true;
        activeButton = button;

        DisplayItem(button.item);
    }

    public void MouseEnterButton(ViewItemButton button)
    {
        button.buttonImage.enabled = true;
    }

    public void MouseExitButton(ViewItemButton button)
    {
        if(activeButton != button)
        {
            button.buttonImage.enabled = false;
        }
    }

    public void DisplayItem(Item item)
    {
        viewer.gameObject.SetActive(true);
        viewer.Setup(playerCharacterSheet, item);
    }

    public void DeactivateDisplay()
    {
        viewer.gameObject.SetActive(false);
    }
}
