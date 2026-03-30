using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character
{
    [SerializeField] private InputActionReference _moveAction;
    
    public float attack = 2.0f;
    public float defense = 2.0f;
    public float fireMagic = 5.0f;

    
    public override void Move()
    {
        InputMovement();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    private void InputMovement()
    { 
        // Get player input and calculate player wish velocity
        Vector2 playerInput = _moveAction.action.ReadValue<Vector2>();
        Vector3 movement = transform.right * playerInput.x + transform.forward * playerInput.y;
        
        base._wishVelocity = movement;
    }

    private void Update()
    {
        Move();
    }
    
    private void FixedUpdate()
    {
        // Set rigidbody velocity
        base._rigidbody.velocity = new Vector3(base._wishVelocity.x * moveSpeed, base._rigidbody.velocity.y, base._wishVelocity.z * moveSpeed);
    }

}
