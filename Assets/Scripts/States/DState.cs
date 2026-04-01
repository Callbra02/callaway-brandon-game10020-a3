using UnityEngine;

public abstract class DState
{
    public DStateMachine stateMachine;
    public string stringName;

    protected DState(DStateMachine _stateMachine, string _stateName = "")
    {
        stateMachine = _stateMachine;
        stringName = _stateName;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}