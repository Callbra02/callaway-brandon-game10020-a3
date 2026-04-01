using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CShopState : CState
{
    public CShopState(CStateMachine _stateMachine) : base(_stateMachine, "Shop") {}

    private bool isWillingToSteal = false;
    
    public override void Enter()
    {
        // Check for steal status
        isWillingToSteal = Random.Range(0.0f, 100.0f) < stateMachine.chanceToSteal;
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        
    }
}