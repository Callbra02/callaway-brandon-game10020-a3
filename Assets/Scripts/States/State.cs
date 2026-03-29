using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateMachine stateMachine;

    protected State(StateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}