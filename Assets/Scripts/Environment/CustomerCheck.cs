using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerCheck : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnCustomerEnter;

    private void Start()
    {
        OnCustomerEnter ??= new UnityEvent();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Customer"))
        {
            OnCustomerEnter.Invoke();
        }
    }
}
