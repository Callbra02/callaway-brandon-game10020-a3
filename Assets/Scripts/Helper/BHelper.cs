using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper class for various functions
public class BHelper : MonoBehaviour
{
    public static string[] itemNames = {"Milk", "Bread", "Candy", "Gift Card" };
    
    public static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static List<Item> GetNewWantedItems(int numberOfItems)
    {
        List<Item> newItemsList = new List<Item>();
        
        for (int i = 0; i < numberOfItems; i++)
        {
            Item newItem = new Item();
            newItem.Randomize();
            newItemsList.Add(newItem);
        }

        return newItemsList;
    }

    public static string GetItemName()
    {
        return itemNames[Random.Range(0, itemNames.Length)];
    }
}
