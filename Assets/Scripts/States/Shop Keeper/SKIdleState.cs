using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shopkeeper Idle State
public class SKIdleState : SKState
{
    public SKIdleState(SKStateMachine _stateMachine) : base(_stateMachine) {}
    
    public override void Enter()
    {
        stateMachine.idleTime = Time.time;
    }

    public override void Execute()
    {
        // Idle logic
        float idleTimeElapsed = Time.time - stateMachine.idleTime;
        
        // If idled to max idle time, change state
        if (idleTimeElapsed >= stateMachine.idleTimeThreshold)
        {
            // If customer is present, change to Sell state
            if (stateMachine.areCustomersPresent)
                stateMachine.ChangeState(new SKSellState(stateMachine));
            // If customer is not present, change to Patrol State
            else
                stateMachine.ChangeState(new SKPatrolState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
