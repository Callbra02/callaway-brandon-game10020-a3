using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMechanic : MonoBehaviour
{
    private bool _isSellWindowOpen = false;
    private bool _isSellAllowed = false;
    
    [SerializeField] private GameObject sellWindowObject;
    
    // Start is called before the first frame update
    void Start()
    {
        sellWindowObject.SetActive(_isSellWindowOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSellMechanic()
    {
        // Do not toggle sell window if selling is not allowed
        if (!_isSellAllowed)
            return;
        
        // Toggle sell window activity
        _isSellWindowOpen = !_isSellWindowOpen;
        sellWindowObject.SetActive(_isSellWindowOpen);
        
        // Unlock Cursor and Lock Cursor when applicable
        if (_isSellWindowOpen)
            BHelper.UnlockCursor();
        else
            BHelper.LockCursor();
        
        
    }

    // Only allow selling when Shopkeeper is in the sell state
    public void ToggleSellActivity()
    {
        Debug.Log("TOGGLE SELL ACTIVITY FIRED");
        _isSellAllowed = !_isSellAllowed;
    }
}
