using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shopkeeper Sell State
public class SKTillState : SKState
{
    // Constructor
    public SKTillState(SKStateMachine _stateMachine) : base(_stateMachine, "Till") {}

    public override void Enter()
    {
        Debug.Log("TILL STATE ENTERED");
    }

    public override void Execute()
    {
        
        //--COMMAND STATE CHECK ---------------------------------------------------------------------
        if (stateMachine.isAlerted)
        {
            stateMachine.ChangeState(new SKCommandState(stateMachine));  //-----> Go To Command State
        }
        //-------------------------------------------------------------------------------------------
        
        // If no customers are present, swap to idle state
        if (!stateMachine.areCustomersPresent)
            stateMachine.ChangeState(new SKIdleState(stateMachine));        //-----> Go To Idle State
        
        // TODO: add logic for setting areCustomersPresent to false

        // Get till position, set agent destination
        Transform tillTransform = stateMachine.tillTransform;
        stateMachine.agent.SetDestination(tillTransform.position);

        // Create vars for distance check
        Vector3 positionXZ = stateMachine.transform.position;
        Vector3 tillPositionXZ = tillTransform.position;
        positionXZ.y = 0.0f;
        tillPositionXZ.y = 0.0f;

        float distance = Vector2.Distance(positionXZ, tillPositionXZ);
        
        // If distance is within threshold, swap to sell state
        if (distance < stateMachine.waypointThreshold)
        {
            stateMachine.ChangeState(new SKSellState(stateMachine));         //-----> Go To Sell State
        }
    }

    public override void Exit()
    {
        
    }
}
