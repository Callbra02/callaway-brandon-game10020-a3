using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shopkeeper Patrol State
public class SKPatrolState : SKState
{
    public SKPatrolState(SKStateMachine _stateMachine) : base(_stateMachine, "Patrol") {}

    public override void Enter()
    {
        Debug.Log("PATROL STATE ENTERED");
    }

    public override void Execute()
    {
        //--COMMAND STATE CHECK ---------------------------------------------------------------------
        if (stateMachine.isAlerted)
        {
            stateMachine.ChangeState(new SKCommandState(stateMachine));  //-----> Go To Command State
        }

        //--TILL STATE CHECK-------------------------------------------------------------------------
        if (stateMachine.areCustomersPresent)
        {
            stateMachine.ChangeState(new SKTillState(stateMachine));
        }
        //-------------------------------------------------------------------------------------------
        
        
        // Set NavMeshAgent destination to current patrol waypoint
        Transform patrolTransform = stateMachine.patrolWaypoints[stateMachine.patrolIndex];
        stateMachine.agent.SetDestination(patrolTransform.position);

        // Calculate distance between our position and the waypoint position
        float distance = BHelper.DistanceXZ(stateMachine.transform.position, patrolTransform.position);
        

        // TODO: insert logic for checking if items are in stock
        // TODO: !allItemsInStock -> Retrieve | allItemsInStock -> Idle
        
        // If distance is within threshold, change state
        if (distance < stateMachine.waypointThreshold)
        {
            if (stateMachine.areItemsInStock)
                stateMachine.ChangeState(new SKIdleState(stateMachine));       //-----> Go To Idle State
            else
                stateMachine.ChangeState(new SKRetrieveState(stateMachine));   //-----> Go To Retrieve State
        }
            
        
    }

    public override void Exit()
    {
        // Increment patrol index
        stateMachine.patrolIndex++;
        
        // Prevent index error | loop through patrol points
        if (stateMachine.patrolIndex >= stateMachine.patrolWaypoints.Length)
            stateMachine.patrolIndex = 0;
    }
}
