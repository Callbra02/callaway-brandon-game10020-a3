using UnityEngine;

public abstract class SKState
{
    public SKStateMachine stateMachine;

    protected SKState(SKStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}