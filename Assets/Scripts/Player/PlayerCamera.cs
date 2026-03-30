using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;
    
    [Header("Input System")]
    public InputActionReference mouseInput;

    [Header("Sensitivity")]
    public float sensitivityMultiplier = 1.0f;
    public float horizontalSensitivity = 1.0f;
    public float verticalSensitivity = 1.0f;

    [Header("Settings")]
    public float minYAngle = -90.0f;
    public float maxYAngle = 90.0f;

    private Vector3 realRotation;

    private void Start()
    {
        playerTransform = this.transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Break logic if game is paused
        if (Mathf.Abs(Time.timeScale) <= 0)
        {
            return;
        }
        
        // Get x and y mouse movement values
        float xMovement = mouseInput.action.ReadValue<Vector2>().x * horizontalSensitivity * sensitivityMultiplier;
        float yMovement = -mouseInput.action.ReadValue<Vector2>().y * verticalSensitivity * sensitivityMultiplier;

        // Calculate rotation
        realRotation = new Vector3(Mathf.Clamp(realRotation.x + yMovement, minYAngle, maxYAngle),
            realRotation.y + xMovement, realRotation.z);
        
        // Lerp z to 0
        realRotation.z = Mathf.Lerp(realRotation.z, 0.0f, Time.deltaTime * 4.0f);

        // Set player transform rotation
        playerTransform.eulerAngles = Vector3.Scale(realRotation, new Vector3(0.0f, 1.0f, 0.0f));

        // Set camera transform
        transform.eulerAngles = realRotation;
    }
}
