using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKiller : MonoBehaviour
{
    public CharacterSheet sheet;
    public GameObject ItemDropPrefab;


    // Start is called before the first frame update
    void Start()
    {
       if(sheet == null)
       {
            sheet = GetComponentInChildren<CharacterSheetHolder>().characterSheet;
       }
       if(sheet == null)
        {
            Debug.LogError("Character sheet not found on character killer component of game object: " + gameObject.name);
            this.enabled = false;
        }

       if(sheet.stats.OnModifyHealth == null)
        {
            sheet.stats.OnModifyHealth = new IntEvent();
        }
        sheet.stats.OnModifyHealth.AddListener(OnTakeDamage);

    }

    public void OnTakeDamage(int amount)
    {
        if(sheet.stats.GetCurrentHealth() <= 0)
        {

            foreach(Item item in sheet.inventory.GetItemsInInventory())
            {
                GameObject g = Instantiate(ItemDropPrefab);
                ItemDrop drop = g.GetComponent<ItemDrop>();
                drop.Setup(item);

                drop.transform.position = this.transform.position;
            }

            Destroy(this.gameObject);

        }
    }
}
