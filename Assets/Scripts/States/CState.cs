using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CState
{
    public CStateMachine stateMachine;

    protected CState(CStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
