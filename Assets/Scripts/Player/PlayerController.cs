using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
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
        UpdateHealthBar();
    }

    public void InputMovement()
    {
        
    }

    public void UpdateHealthBar()
    {
        
    }
}
