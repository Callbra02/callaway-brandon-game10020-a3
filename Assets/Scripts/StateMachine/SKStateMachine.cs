using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SKStateMachine : MonoBehaviour
{
    public Transform character;
    public Transform[] patrolWaypoints;

    public int patrolIndex = 0;
    public NavMeshAgent agent;
    
    public float idleTime;
    public float waypointThreshold = 0.6f;
    
    public bool areCustomersPresent = false;

    public float idleTimeThreshold = 2.0f;
    
    private SKState currentState;

    private void Awake()
    {
        currentState = new SKIdleState(this);
    }

    public void ChangeState(SKState newState)
    {
        // Exit current state, if it exists
        if (currentState != null)
        {
            currentState.Exit();
        }

        // Update current state and enter the new state
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        // Process current state logic, if it exists
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
