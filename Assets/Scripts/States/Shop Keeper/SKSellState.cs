using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shopkeeper Sell State
public class SKSellState : SKState
{
    public SKSellState(SKStateMachine _stateMachine) : base(_stateMachine) {}

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        // TODO: add logic for interacting with players & customers
        // TODO: add logic for setting areCustoemrsPresent to false
        
        if (!stateMachine.areCustomersPresent)
            stateMachine.ChangeState(new SKIdleState(stateMachine));
    }

    public override void Exit()
    {
        
    }
}
