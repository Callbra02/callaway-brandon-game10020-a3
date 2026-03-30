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
        //base._wishVelocity = Vector3.zero;
        
        Vector2 newVelocity = _moveAction.action.ReadValue<Vector2>();
        
        //base._wishVelocity = new Vector3(newVelocity.x, _rigidbody.velocity.y, newVelocity.y);
       // base._wishVelocity *= moveSpeed * Time.deltaTime;

       Vector3 movement = transform.right * newVelocity.x + transform.forward * newVelocity.y;

       base._wishVelocity = movement;
    }

    private void Update()
    {
        Move();
    }
    
    private void FixedUpdate()
    {
        base._rigidbody.velocity = new Vector3(base._wishVelocity.x * moveSpeed, base._rigidbody.velocity.y, base._wishVelocity.z * moveSpeed);
    }

}
