using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CustomerCheck customerCheck;

    public SKStateMachine shopkeeperFSM;

    private void Start()
    {
        customerCheck.OnCustomerEnter.AddListener(shopkeeperFSM.CustomerEntry);
    }

    private void Update()
    {
        
    }
    
    
}
