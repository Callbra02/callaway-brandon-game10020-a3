using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DEBUGSCRIPT : MonoBehaviour
{
    public GameObject debugPanel;
    public TextMeshProUGUI customerStateText;
    public TextMeshProUGUI shopkeeperStateText;
    public TextMeshProUGUI customerCheckText;

    public SKStateMachine shopkeeperFSM;
    public CStateMachine customerFSM;
    [SerializeField] private InputActionReference debugAction;
    private bool _TOGGLE = false;

    private void Start()
    {
        ClosePanel();
    }
    
    private void Update()
    {
        if (debugAction.action.WasPressedThisFrame())
        {
            _TOGGLE = !_TOGGLE;
        }

        if (!_TOGGLE)
        {
            ClosePanel();
            return;
        }

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
