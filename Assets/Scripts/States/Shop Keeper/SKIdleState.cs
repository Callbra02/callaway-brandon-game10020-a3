using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shopkeeper Idle State
public class SKIdleState : SKState
{
    public SKIdleState(SKStateMachine _stateMachine) : base(_stateMachine, "Idle") {}
    
    public override void Enter()
    {
        // Get idle time
        stateMachine.idleTime = Time.time;
        Debug.Log("IDLE STATE ENTERED");
    }

    public override void Execute()
    {
        //--COMMAND STATE CHECK ---------------------------------------------------------------------
        if (stateMachine.isAlerted)
        {
            stateMachine.ChangeState(new SKCommandState(stateMachine));  //-----> Go To Command State
        }
        //-------------------------------------------------------------------------------------------
        
        // Idle logic
        float idleTimeElapsed = Time.time - stateMachine.idleTime;
        
        // If idled to max idle time, change state
        if (idleTimeElapsed >= stateMachine.idleTimeThreshold)
        {
            // If customer is present, change to Sell state
            if (stateMachine.areCustomersPresent)
                stateMachine.ChangeState(new SKTillState(stateMachine));    //-----> Go To Till State
            // If customer is not present, change to Patrol State
            else
                stateMachine.ChangeState(new SKPatrolState(stateMachine));  //-----> Go To Patrol State
        }
    }

    public override void Exit()
    {
        
    }
}
