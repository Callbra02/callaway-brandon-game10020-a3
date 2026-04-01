using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnterState : CState
{
    public CEnterState(CStateMachine _stateMachine) : base(_stateMachine, "Enter") {}

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        Transform entryTransform = stateMachine.entryTransform;
        stateMachine.agent.SetDestination(entryTransform.position);

        float distance = BHelper.DistanceXZ(stateMachine.transform.position, entryTransform.position);

        if (distance < stateMachine.waypointThreshold)
        {
            stateMachine.ChangeState(new CShopState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
