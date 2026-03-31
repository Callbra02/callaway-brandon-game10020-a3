using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Shop Keeper state machine
public class SKStateMachine : MonoBehaviour
{
    public Shopkeeper shopkeeperScript;
    
    // Patrol vars
    public Transform[] patrolWaypoints;
    public int patrolIndex = 0;
    public NavMeshAgent agent;
    public float waypointThreshold = 0.6f;
    
    // Sell vars
    public bool areCustomersPresent = false;
    public Transform tillTransform;
    
    // Idle vars
    public float idleTime;
    public float idleTimeThreshold = 2.0f;
    
    
    // Current state variable
    private SKState currentState;

    private void Awake()
    {
        shopkeeperScript = GetComponent<Shopkeeper>();
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

    public void CustomerEntry()
    {
        areCustomersPresent = true;
    }

    public void CustomerExit()
    {
        areCustomersPresent = false;
    }
}
