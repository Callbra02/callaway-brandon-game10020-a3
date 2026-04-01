using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject;
    public SellMechanic sellMechanic;
    public CustomerCheck customerCheck;
    public SKStateMachine shopkeeperFSM;

    private void Start()
    {
        customerCheck.OnCustomerEnter.AddListener(shopkeeperFSM.CustomerEntry);
        customerCheck.OnCustomerExit.AddListener(shopkeeperFSM.CustomerExit);
        playerObject.GetComponent<InteractionMechanic>().OnCharacterInteraction.AddListener(sellMechanic.ToggleSellMechanic);
        shopkeeperFSM.shopkeeperScript.OnSellState.AddListener(sellMechanic.ToggleSellActivity);
    }

    private void Update()
    {
        
    }
    
    
}
