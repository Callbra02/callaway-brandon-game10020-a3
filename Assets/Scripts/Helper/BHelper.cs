using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper class for various functions
public class BHelper : MonoBehaviour
{
    public static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
