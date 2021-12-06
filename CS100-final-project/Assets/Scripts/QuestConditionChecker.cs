using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestConditionChecker
{
    [System.Serializable]
    public struct RequiredQuestNode
    {
        public enum NodeStatus { available, failed, completed };
        public NodeStatus requiredNodeStatus;
        public bool requiredState;
        public QuestNodeBase questNode;

    }

    public List<RequiredQuestNode> requiredQuestNodes;


    public bool ConditionsAreMet()
    {
        if(requiredQuestNodes.Count == 0)
        {
            return true;
        }

        foreach (RequiredQuestNode node in requiredQuestNodes)
        {
            switch (node.requiredNodeStatus)
            {
                case RequiredQuestNode.NodeStatus.available:
                    if (node.questNode.available != node.requiredState)
                    {
                        return false;
                    }
                    break;
                case RequiredQuestNode.NodeStatus.failed:
                    if (node.questNode.failed != node.requiredState)
                    {
                        return false;
                    }
                    break;

                case RequiredQuestNode.NodeStatus.completed:
                    if (node.questNode.completed != node.requiredState)
                    {
                        return false;
                    }
                    break;

                default:
                    break;

            }


        }


        return true;
    }
}
