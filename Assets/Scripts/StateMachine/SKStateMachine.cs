using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

// Shop Keeper state machine
public class SKStateMachine : MonoBehaviour
{
    public Shopkeeper shopkeeperScript;
    public TextMeshProUGUI stateText;
    public bool displayState = true;
    
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
    
    // Retrieve vars
    public bool areItemsInStock = true;
    public bool currentlyHasItem = false;
    
    // Command vars
    public bool isAlerted = false;

    private int customersInStore = 0;
    
    // Current state variable
    private SKState currentState;

    private void Awake()
    {
        shopkeeperScript = GetComponent<Shopkeeper>();
        
        // Enter Idle State
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
        
        stateText.text = displayState ? currentState.stringName + " State Entered" : "";
    }

    public void Update()
    {
        // Process current state logic, if it exists
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    // Call for SellMechanic script event
    public void CustomerEntry()
    {
        areCustomersPresent = true;
        customersInStore++;
    }

    // Call for SellMechanic script event
    public void CustomerExit()
    {
        customersInStore--;
        
        // Only set customers presence to false if all customers leave the store
        if (customersInStore <= 0)
            areCustomersPresent = false;
    }
}
