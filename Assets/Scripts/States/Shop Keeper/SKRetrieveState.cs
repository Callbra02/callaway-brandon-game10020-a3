using UnityEngine;

// Shopkeeper Retrieve State
public class SKRetrieveState : SKState
{
    
    public SKRetrieveState(SKStateMachine _stateMachine) : base(_stateMachine, "Retrieve") {}
    
    public override void Enter()
    {
        Debug.Log("RETRIEVE STATE ENTERED");
    }
    
    public override void Execute()
    {
        //--COMMAND STATE CHECK ---------------------------------------------------------------------
        if (stateMachine.isAlerted)
        {
            stateMachine.ChangeState(new SKCommandState(stateMachine));  //-----> Go To Command State
        }
        //-------------------------------------------------------------------------------------------
        
        if (stateMachine.currentlyHasItem)
        {
            stateMachine.ChangeState(new SKStockState(stateMachine));    //-----> Go To Stock State
        }
    }
    
    public override void Exit()
    {
        
    }
}