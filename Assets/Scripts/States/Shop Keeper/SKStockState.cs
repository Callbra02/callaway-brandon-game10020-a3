using UnityEngine;

// Shopkeeper Stock State
public class SKStockState : SKState
{
    
    public SKStockState(SKStateMachine _stateMachine) : base(_stateMachine, "Stock") {}

    private bool isCurrentItemBackInStock = false;
    
    public override void Enter()
    {
        Debug.Log("STOCK STATE ENTERED");
    }
    
    public override void Execute()
    {
        //--COMMAND STATE CHECK ---------------------------------------------------------------------
        if (stateMachine.isAlerted)
        {
            stateMachine.ChangeState(new SKCommandState(stateMachine));  //-----> Go To Command State
        }
        //-------------------------------------------------------------------------------------------
        
        if (!isCurrentItemBackInStock)
            return;
        
        
        if (stateMachine.areItemsInStock)
        {
            stateMachine.ChangeState(new SKIdleState(stateMachine));      //-----> Go To Idle State
        }
        else
        {
            stateMachine.ChangeState(new SKPatrolState(stateMachine));     //-----> Go To Patrol State
        }
        
        
    }
    
    public override void Exit()
    {
        
    }
}