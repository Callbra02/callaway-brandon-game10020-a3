using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKSellState : SKState
{
    public SKSellState(SKStateMachine _stateMachine) : base(_stateMachine) {}

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        // TODO: add logic for interacting with players & customers
        
        // If no customers are present, swap to idle state
        if (!stateMachine.areCustomersPresent)
            stateMachine.ChangeState(new SKIdleState(stateMachine));
        
        // Look for interaction
        // Allow 
    }

    public override void Exit()
    {
        
    }
}
