using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UseItemButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TMP_Text buttonText;
    public Image buttonImage;
    public UseItemStrategy strategy;

    public UnityEvent OnUseItem;

    public void Setup(Item item, UseItemStrategy strat) // also pass as reference the UI viewer
    {
        if (item as WeaponItem != null)
        {
            buttonText.text = "Equip " + item.GetName();
        }
        else if (item as ConsumableItem != null)
        {
            buttonText.text = "Consume " + item.GetName();
        }
        else if (item as ArmorItem != null)
        {
            buttonText.text = "Equip " + item.GetName();
        }

        strategy = strat;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        buttonImage.enabled = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        buttonImage.enabled = false;
    }

    public void OnPointerClick(PointerEventData data)
    {
        strategy.Execute();

        if(OnUseItem != null)
        {
            OnUseItem.Invoke();
        }

        OnUseItem.RemoveAllListeners();
    }

}
