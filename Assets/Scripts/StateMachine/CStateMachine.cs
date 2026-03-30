using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateMachine : MonoBehaviour
{
    private CState currentState;
    
    private void Awake()
    {
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
