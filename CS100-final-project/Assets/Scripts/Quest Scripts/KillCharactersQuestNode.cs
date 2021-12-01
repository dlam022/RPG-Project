using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Quest Item Quest Node", menuName = "Custom Scriptable Objects/Quests/Kill Characters Quest Node")]
public class KillCharactersQuestNode : QuestNodeBase
{
    public CharacterSheet playersCharacterSheet;
    public string TargetNPC;
    public int amountRequired;
    public int amountKilled;

    public void NPCKilled(CharacterSheet characterKilled)
    {
        if (characterKilled.CharacterName == TargetNPC)
        {
            amountKilled++;

            parentQuest.DisplayQuestNotification("Quest Updated: " + nodeTitle + "(" + amountKilled + "/" + amountRequired + ")");

            if (amountKilled >= amountRequired)
            {
                MarkAsComplete();
            }



        }
    }

    public override void MarkAsComplete()
    {
        base.MarkAsComplete();

        if (playersCharacterSheet != null)
        {
            if (playersCharacterSheet.OnKillsCharacter == null)
            {
                playersCharacterSheet.OnKillsCharacter = new CharacterSheetEvent();
            }

            playersCharacterSheet.OnKillsCharacter.RemoveListener(NPCKilled);
        }
    }

    public override void MarkAsAvailable()
    {
        available = true;

        if (OnNodeAvailable != null)
        {
            OnNodeAvailable.Invoke();
        }




        if (playersCharacterSheet != null)
        {
            if (playersCharacterSheet.OnKillsCharacter == null)
            {
                playersCharacterSheet.OnKillsCharacter = new CharacterSheetEvent();
            }

            playersCharacterSheet.OnKillsCharacter.AddListener(NPCKilled);
        }

        int amount = 0;
       
        amountKilled = amount;
        parentQuest.DisplayQuestNotification("Quest Updated: " + nodeTitle + "(" + amountKilled + "/" + amountRequired + ")");

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
        if (playersCharacterSheet != null)
        {
            if (playersCharacterSheet.OnKillsCharacter == null)
            {
                playersCharacterSheet.OnKillsCharacter = new CharacterSheetEvent();
            }

            amountKilled = 0;
            playersCharacterSheet.OnKillsCharacter.RemoveListener(NPCKilled);
        }
    }

    public override void LoadSaveData(string path)
    {
        base.LoadSaveData(path);

        if (available && !completed && playersCharacterSheet != null)
        {
            
            if (playersCharacterSheet.OnKillsCharacter == null)
            {
                 playersCharacterSheet.OnKillsCharacter = new CharacterSheetEvent();
            }

            playersCharacterSheet.OnKillsCharacter.AddListener(NPCKilled);
        }
    }

}
