using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerCheck : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnCustomerEnter;
    [HideInInspector] public UnityEvent OnCustomerExit;

    private void Start()
    {
        OnCustomerEnter ??= new UnityEvent();
        OnCustomerExit ??= new UnityEvent();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Customer"))
        {
            OnCustomerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Customer"))
        {
            OnCustomerExit.Invoke();
        }
    }
}
