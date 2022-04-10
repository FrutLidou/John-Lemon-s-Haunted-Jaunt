using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Vector3 lastKnownPosition;
    public Transform player;
    public GameEnding gameEnding;
    public float caughtDistance = 1f;
    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        lastKnownPosition = Vector3.zero;
    }
    
    void Update()
    {
        if (lastKnownPosition != Vector3.zero)
        {
            //Hunt the player
            navMeshAgent.SetDestination(lastKnownPosition);
            if (Vector3.Distance(this.transform.position, player.position) < caughtDistance)
            {
                //Caught the player
                gameEnding.CaughtPlayer();
            }
            else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                //Player is not at last known position, resume patrol
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                lastKnownPosition = Vector3.zero;
            }
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
