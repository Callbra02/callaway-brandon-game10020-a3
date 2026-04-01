using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    protected NavMeshAgent _agent;
    public int numberOfWantedItems = 5;

    protected Dictionary<Item, int> _wantedItems = new Dictionary<Item, int>();
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        // Get list of new wanted items
        List<Item> itemList = BHelper.GetNewWantedItems(numberOfWantedItems);

        // Append list of wanted items to _wantedItems dict and set total amount
        // of all items to 0
        for (int i = 0; i < itemList.Count; i++)
        {
            _wantedItems.Add(itemList[i], 0);
        }
        
        
    }
}
