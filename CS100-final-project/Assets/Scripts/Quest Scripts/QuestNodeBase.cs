using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

[CreateAssetMenu(fileName = "Quest Node Base", menuName = "Custom Scriptable Objects/Quests/Quest Node Base")]
public class QuestNodeBase : ScriptableObject
{
    public Quest parentQuest;

    public string nodeTitle;
    public string NodeID;
    [TextArea]
    public string uncompletedNodeDescription;
    [TextArea]
    [Tooltip("If the completed node description is empty, it will not be displayed in the quest nodes description page.")]
    public string completedNodeDescription;


    public bool available;
    public bool completed;
    public bool failed;

    public List<QuestNodeBase> prerequisiteQuestNodes;

    public UnityEvent OnNodeFail;
    public UnityEvent OnNodeComplete;
    public UnityEvent OnNodeAvailable;

    public Vector2 markerLocationInOverworld;

    [System.Serializable]
    public struct MarkerLocationInBuilding
    {
        public Vector2 location;
        public SceneAsset sceneAsset;
    }

    public List<MarkerLocationInBuilding> markerLocationsInBuilding;

    [System.Serializable]
    private struct SaveData
    {
        public bool available;
        public bool completed;
        public bool failed;

    }


    public virtual void MarkAsFailed()
    {
        failed = true;
        if (OnNodeFail != null)
        {
            OnNodeFail.Invoke();
        }

    }

    public virtual void MarkAsComplete()
    {
        completed = true;
        if (OnNodeComplete != null)
        {
            OnNodeComplete.Invoke();
        }

        parentQuest.DisplayQuestNotification("Completed: " + nodeTitle);

    }

    public virtual void MarkAsAvailable()
    {
        available = true;
        
        if (OnNodeAvailable != null)
        {
            OnNodeAvailable.Invoke();
        }
        parentQuest.DisplayQuestNotification("Quest Updated: " + nodeTitle);
    }

    public void ReevaluateAvailability()
    {
        foreach (QuestNodeBase questNode in prerequisiteQuestNodes)
        {
            if (questNode.available != true)
            {
                return;
            }
        }


        MarkAsAvailable();
    }

    public virtual QuestNodeBase CreateRuntimeCopy()
    {
        QuestNodeBase copy = ScriptableObject.CreateInstance<QuestNodeBase>();

        copy.parentQuest = parentQuest;

        copy.nodeTitle = nodeTitle;
        copy.completedNodeDescription = completedNodeDescription;
        copy.uncompletedNodeDescription = completedNodeDescription;
        copy.NodeID = NodeID;

        copy.available = available;
        copy.completed = completed;
        copy.failed = failed;

        copy.prerequisiteQuestNodes = prerequisiteQuestNodes;
        copy.markerLocationInOverworld = markerLocationInOverworld;

        return copy;
    }

    public virtual void OnValidate()
    {
        UnityAction ua = new UnityAction(ReevaluateAvailability);


        foreach(QuestNodeBase node in prerequisiteQuestNodes)
        {
            if(node != null)
            {
                if( node.OnNodeComplete == null)
                {
                 node.OnNodeComplete = new UnityEvent();
                }

                node.OnNodeComplete.RemoveListener(ua);
                node.OnNodeComplete.AddListener(ua);
            }         
        }
    }

    public virtual void ResetNode()
    {
        available = false;
        failed = false;
        completed = false;
    }
}
