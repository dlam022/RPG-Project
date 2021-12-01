using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachLocationQuestNodeGameObject : MonoBehaviour
{
    public Collider2D coll;
    public QuestNodeBase questNode;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        if(questNode.available && !questNode.completed)
        {
            coll.enabled = true;
        }
        else if(questNode.completed)
        {
            gameObject.SetActive(false);
        }
        else
        {
            coll.enabled = false;
        }

        if(questNode.OnNodeAvailable == null)
        {
            questNode.OnNodeAvailable = new UnityEvent();
        }
        questNode.OnNodeAvailable.AddListener(ActivateCollider);

        if (questNode.OnNodeComplete == null)
        {
            questNode.OnNodeComplete = new UnityEvent();
        }
        questNode.OnNodeComplete.AddListener(DeativateCollider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
        
            questNode.MarkAsComplete();
            this.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    public void ActivateCollider()
    {
        coll.enabled = true;
    }

    public void DeativateCollider()
    {
        coll.enabled = false;
    }

    private void OnDisable()
    {
        questNode.OnNodeAvailable.RemoveListener(ActivateCollider);
    }
}
