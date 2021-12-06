using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public DialogueManager manager;
    public DialogueNodeScript node;
    public TMP_Text buttonText;
    public Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage.enabled = false;
    }

    public void SetupButton(DialogueNodeScript n)
    {
        node = n;

        buttonText.text = node.LeadInTextForButton;
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
        manager.SetupTextBox(node);
    }
}
