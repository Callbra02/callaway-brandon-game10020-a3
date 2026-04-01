using UnityEngine;

// Shopkeeper CommandState
public class SKCommandState : SKState
{
    public SKCommandState(SKStateMachine _stateMachine) : base(_stateMachine, "Command") {}
    
    public override void Enter()
    {
        Debug.Log("COMMAND STATE ENTERED");
    }
    
    public override void Execute()
    {
        
    }
    
    public override void Exit()
    {
        
    }
}
