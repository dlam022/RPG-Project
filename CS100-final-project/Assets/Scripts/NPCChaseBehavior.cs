using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChaseBehavior : MonoBehaviour
{
    [SerializeField]
    private NPCPatrolBehavior patrolBehavior;
    [SerializeField]
    private NPCMovement mover;

    private bool inPursuit = false;

    [SerializeField]
    private float counterMaxTime;
    private float CheckCounter;

    //Distance the NPC can check for the player
    [Tooltip("Distance the NPC can check for the player")]
    public float visionRadius;

    // Start is called before the first frame update
    void Start()
    {
        if(mover == null)
        {
            mover = GetComponent<NPCMovement>();
        }
        if(patrolBehavior == null)
        {
            patrolBehavior = GetComponent<NPCPatrolBehavior>();
        }

        CheckCounter = counterMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(inPursuit)
        {
            return;
        }

        CheckCounter -= Time.deltaTime;

        if(CheckCounter <=0)
        {
            if(PlayerNearby())
            {
                StartCoroutine(Pursue());
            }

            CheckCounter = counterMaxTime;
        }
    }

    private bool PlayerNearby()
    {
        RaycastHit2D [] nearbyHits = Physics2D.CircleCastAll(transform.position, visionRadius, Vector2.zero);
        foreach(RaycastHit2D hit in nearbyHits)
        {
            //if the collider is attached to a game object tagged as the player
            if(hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }


    public IEnumerator Pursue()
    {
        patrolBehavior.StopPatrolling();

        //Find the player game object by tag and get a reference to it's transform
        Transform playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        while(Vector3.Distance(transform.position, playerReference.position) < visionRadius + 2f)
        {
            //At this distance the NPC will be directly next to the player
            if(Vector3.Distance(transform.position, playerReference.position) > 0.65f)
            {
                Vector3 heading = (playerReference.position - transform.position).normalized;
                mover.Move(heading);
            }
            yield return null;
        }

        patrolBehavior.ResumePatrolling();
        yield return null;
    }
}
