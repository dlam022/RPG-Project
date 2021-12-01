using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Quest Item Quest Node", menuName = "Custom Scriptable Objects/Quests/Quest Item Quest Node")]
public class AddItemToInventoryQuestNode : QuestNodeBase
{
    public Inventory playersInventory;
    public Item requiredItem;
    public int amountRequired;
    public int amountFound;


    public void ItemAdded(Item item)
    {
        if(item.GetName() == requiredItem.GetName())
        {
            amountFound++;

            parentQuest.DisplayQuestNotification("Quest Updated: " + nodeTitle + "(" + amountFound + "/" + amountRequired + ")");

            if (amountFound >= amountRequired)
            {
                MarkAsComplete();
            }


            
        }
    }

    public override void MarkAsComplete()
    {
        base.MarkAsComplete();

        if (playersInventory != null)
        {
            if (playersInventory.OnAddItem == null)
            {
                playersInventory.OnAddItem = new ItemEvent();
            }

            playersInventory.OnAddItem.RemoveListener(ItemAdded);
        }
    }

    public override void MarkAsAvailable()
    {
        available = true;

        if (OnNodeAvailable != null)
        {
            OnNodeAvailable.Invoke();
        }
   

 

        if (playersInventory != null)
        {
            if (playersInventory.OnAddItem == null)
            {
                playersInventory.OnAddItem = new ItemEvent();
            }

            playersInventory.OnAddItem.AddListener(ItemAdded);
        }

        int amount = 0;
        foreach (Item item in playersInventory.GetItemsInInventory())
        {
            if(item.GetName() == requiredItem.GetName())
            {
                amount++;
            }
        }
        amountFound = amount;
        parentQuest.DisplayQuestNotification("Quest Updated: " + nodeTitle + "("+ amountFound + "/" +amountRequired + ")");

        Debug.Log("Starting node with " + amountFound + " of required item");
    }

    public override void OnValidate()
    {
        UnityAction ua = new UnityAction(ReevaluateAvailability);


        foreach (QuestNodeBase node in prerequisiteQuestNodes)
        {
            if (node != null)
            {
                if (node.OnNodeComplete == null)
                {
                    node.OnNodeComplete = new UnityEvent();
                }

                node.OnNodeComplete.RemoveListener(ua);
                node.OnNodeComplete.AddListener(ua);
            }
        }
    }

    public override void ResetNode()
    {
        base.ResetNode();
        if(playersInventory != null && playersInventory.OnAddItem != null)
        {
            playersInventory.OnAddItem.RemoveListener(ItemAdded);
        }
       
    }

    public override void LoadSaveData(string path)
    {
        base.LoadSaveData(path);

        if (playersInventory != null && playersInventory.OnAddItem != null && available && !completed)
        {
            playersInventory.OnAddItem.RemoveListener(ItemAdded);
            playersInventory.OnAddItem.AddListener(ItemAdded);
        }
    }

}
