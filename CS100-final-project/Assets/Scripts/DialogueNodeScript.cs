using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Custom Scriptable Objects/Dialogue Node", fileName = "Dialogue Node")]
public class DialogueNodeScript : ScriptableObject
{
  
    public string CharacterName;


    public bool visitOnce;
    public bool PreviouslyVisited;

    public List<DialogueNodeScript> Options;
    
    [TextArea]
    public string MainBodyString ="";
    [TextArea]
    public string LeadInTextForButton = "";

    public QuestConditionChecker conditional;

    [System.Serializable]
    public struct EventTriggers
    {
        public UnityEvent EventTrigger;
        public int triggerCount;

    }
    public List<EventTriggers> eventsTriggeredOnSelectNode;

    public virtual bool IsAvailable()
    {
        return conditional.ConditionsAreMet();
    }

}
