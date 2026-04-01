using UnityEngine;

public abstract class SKState
{
    public SKStateMachine stateMachine;
    public string stringName;

    protected SKState(SKStateMachine _stateMachine, string _stateName = "")
    {
        stateMachine = _stateMachine;
        stringName = _stateName;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}