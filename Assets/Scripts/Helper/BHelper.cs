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

    public static float DistanceXZ(Vector3 transformPosition, Vector3 waypointPosition)
    {
        transformPosition.y = 0;
        waypointPosition.y = 0;

        return Vector2.Distance(transformPosition, waypointPosition);
    }
}
