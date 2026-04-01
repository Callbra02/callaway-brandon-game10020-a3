using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKSellState : SKState
{
    public SKSellState(SKStateMachine _stateMachine) : base(_stateMachine, "Sell") {}

    public override void Enter()
    {
        // Enable sell state
        stateMachine.shopkeeperScript.OnSellState.Invoke();
        Debug.Log("SELL STATE ENTERED");
    }

    public override void Execute()
    {
        
        //--COMMAND STATE CHECK ---------------------------------------------------------------------
        if (stateMachine.isAlerted)
        {
            stateMachine.ChangeState(new SKCommandState(stateMachine));  //-----> Go To Command State
        }
        //-------------------------------------------------------------------------------------------
        
        // TODO: add logic for interacting with players & customers
        
        // If no customers are present, swap to idle state
        if (!stateMachine.areCustomersPresent)
            stateMachine.ChangeState(new SKIdleState(stateMachine));      //-----> Go To Idle State
        
        // Look for interaction
    }

    public override void Exit()
    {
        // Disable sell state
        stateMachine.shopkeeperScript.OnSellState.Invoke();
    }
}
