using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class will cause NPCs to wander between predefined locations
public class NPCPatrolBehavior : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> PatrolPositions = new List<Vector3>();
    [SerializeField]
    private int targetIndex = 0;

    [SerializeField]
    private bool activelyPatrolling = true;

    //Upon reaching the destination we will pause for some amount of time between min and max
    public float DestinationDelay;
    public float min, max;

    [SerializeField]
    private NPCMovement mover;

    // Start is called before the first frame update
    void Start()
    {
        if(mover == null)
        {
            mover = GetComponent<NPCMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!activelyPatrolling)
        {
            return;
        }

        if(DestinationDelay >=0)
        {
            DestinationDelay -= Time.deltaTime;
            return;
        }

        if(Vector3.Distance(transform.position, PatrolPositions[targetIndex]) < 0.1f)
        {
            Random.InitState((int)Time.realtimeSinceStartup);
            DestinationDelay = Random.Range(min, max);

            if(targetIndex == PatrolPositions.Count -1)
            {
                targetIndex = 0;
            }
            else
            {
                targetIndex++;
            }

            return;
        }

        Vector3 heading = GetHeading();
        mover.Move(heading);
    }

    private Vector3 GetHeading()
    {
        Vector3 heading = (PatrolPositions[targetIndex] - transform.position).normalized;

        return heading;
    }

    

    public void StopPatrolling()
    {
        activelyPatrolling = false;
    }

    public void ResumePatrolling()
    {
        activelyPatrolling = true;
    }

    public bool IsPatrolling()
    {
        return activelyPatrolling;
    }
}
