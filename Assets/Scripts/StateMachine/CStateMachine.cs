using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Customer state machine
public class CStateMachine : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Customer customerScript;

    [Range(0.0f, 100.0f)]
    public float chanceToSteal = 25.0f;
    
    public CState currentState { get; private set; }

    public Transform entryTransform;

    public float waypointThreshold = 0.6f;
    
    private void Awake()
    {
        customerScript = GetComponent<Customer>();
        agent = GetComponent<NavMeshAgent>();
        currentState = new CEnterState(this);
    }

    public void ChangeState(CState newState)
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
