using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DEBUGSCRIPT : MonoBehaviour
{
    [Header("Debug Panel")]
    public GameObject debugPanel;
    
    [Header("TMPro Text Objects")]
    public TextMeshProUGUI customerStateText;
    public TextMeshProUGUI shopkeeperStateText;
    public TextMeshProUGUI customerCheckText;

    [Header("Finite State Machines")]
    public SKStateMachine shopkeeperFSM;
    public CStateMachine customerFSM;
    
    [Header("Input System")]
    [SerializeField] private InputActionReference debugAction;
    
    
    private bool _TOGGLE = false;

    private void Start()
    {
        ClosePanel();
    }
    
    private void Update()
    {
        // Toggle panel on debug action press
        if (debugAction.action.WasPressedThisFrame())
        {
            _TOGGLE = !_TOGGLE;
        }

        // If panel should be closed, close panel and break from logic
        if (!_TOGGLE)
        {
            ClosePanel();
            return;
        }

        // Else open panel and display text
        OpenPanel();
        
        HandleText("Shopkeeper: ", shopkeeperFSM.currentState, shopkeeperStateText);
        HandleText("Customer: ", customerFSM.currentState, customerStateText);
        
    }

    private void ClosePanel()
    {
        if (debugPanel.activeSelf)
            debugPanel.SetActive(false);
    }

    private void OpenPanel()
    {
        if (!debugPanel.activeSelf)
            debugPanel.SetActive(true);
    }

    // Overloaded HandleText func for different state types
    private void HandleText(string introText, SKState state, TextMeshProUGUI debugTextRef)
    {
        debugTextRef.text = $"{introText} {state.stringName}";
    }

    private void HandleText(string introText, CState state, TextMeshProUGUI debugTextRef)
    {
        debugTextRef.text = $"{introText} {state.stringName}";
    }
    
    private void HandleText(string introText, DState state, TextMeshProUGUI debugTextRef)
    {
        debugTextRef.text = $"{introText} {state.stringName}";
    }
    
}
