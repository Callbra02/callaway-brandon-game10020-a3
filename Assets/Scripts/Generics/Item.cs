using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName = "";
    public int cashValue = 0;

    public Item()
    {
        Randomize();
    }
    
    public void Randomize()
    {
        itemName = BHelper.GetItemName();
        
        // Set cash value to something random
        // Fix this with specific values per given item
        cashValue = Random.Range(1, 65);
    }
}
