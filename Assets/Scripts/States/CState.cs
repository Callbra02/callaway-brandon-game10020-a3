using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CState
{
    public CStateMachine stateMachine;
    public string stringName;

    protected CState(CStateMachine _stateMachine, string _stateName = "")
    {
        stateMachine = _stateMachine;
        stringName = _stateName;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
