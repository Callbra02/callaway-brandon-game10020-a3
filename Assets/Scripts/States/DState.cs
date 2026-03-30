using UnityEngine;

public abstract class DState
{
    public DStateMachine stateMachine;

    protected DState(DStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}