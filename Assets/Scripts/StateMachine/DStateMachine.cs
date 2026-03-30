using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DStateMachine : MonoBehaviour
{
    public int patrolIndex = 0;
    public NavMeshAgent agent;
    
    public float idleTime;
    public float waypointThreshold = 0.6f;
    

    public float idleTimeThreshold = 2.0f;
    
    private DState currentState;

    private void Awake()
    {
        currentState = new DIdleState(this);
    }

    public void ChangeState(DState newState)
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