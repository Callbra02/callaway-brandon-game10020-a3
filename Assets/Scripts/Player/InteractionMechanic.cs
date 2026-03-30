using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionMechanic : MonoBehaviour
{
    private bool _interactableInRange = false;
    private GameObject _currentInteractable;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _maxInteractDistance = 5.0f;
    [SerializeField] private InputActionReference _interactAction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        HandleRaycast();
        HandleInput();

    }

    // If raycast hits an interactable, set current interactable accordingly
    private void HandleRaycast()
    {
        RaycastHit hit;

        if (Physics.SphereCast(_cameraTransform.position, 0.5f, _cameraTransform.forward, out hit,
                _maxInteractDistance))
        {
            _interactableInRange = hit.transform.gameObject.CompareTag("Interactable");
            
            _currentInteractable = _interactableInRange ? hit.transform.gameObject : null;
        }
    }

    private void HandleInput()
    {
        // If we interact with a valid interactable, proceed
        if (_interactAction.action.WasPressedThisFrame() && _currentInteractable != null)
        {
            Debug.Log("Interactable interacted with within range");
        }
    }
}
