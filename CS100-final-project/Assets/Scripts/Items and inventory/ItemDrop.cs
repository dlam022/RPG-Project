using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof (SpriteRenderer))]
public class ItemDrop : MonoBehaviour
{
    public bool PlayerInRange;

    public Color InRangeColor;
    public Color NotInRangeColor;

    public GameObject NotificationPrefab;
    public GameObject Notification;

    public Item DroppedItem;
    public TMP_Text promptText;

    public void Start()
    {
        if(DroppedItem != null)
        {
            Setup(DroppedItem);
        }
       
    }

    public void Setup(Item item)
    {
        DroppedItem = item;
        Notification = Instantiate(NotificationPrefab);
        Notification.transform.SetParent(transform);

        promptText = Notification.GetComponentInChildren<TMP_Text>();
        promptText.text = "(e) Pickup " + item.GetName();
        promptText.fontSize = 0.5f;

        Notification.transform.position = transform.position
            + new Vector3(0, 2f, 0);

        Notification.SetActive(true);
    }


    public void Update()
    {
        if(PlayerInRange && Input.GetKeyDown("e"))
        {
            CharacterSheet sheet = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterSheetHolder>().characterSheet;
            sheet.inventory.AddItemToInventory(DroppedItem);

            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            if(promptText != null)
            {
                promptText.color = InRangeColor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            if (promptText != null)
            {
                promptText.color = NotInRangeColor;
            }
        }
    }
}
