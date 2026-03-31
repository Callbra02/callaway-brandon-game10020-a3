using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shopkeeper : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnSellState;

    private void Start()
    {
        OnSellState ??= new UnityEvent();
    }
}
