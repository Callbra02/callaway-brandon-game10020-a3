using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName = "Player Name";
    public float health = 100.0f;

    private Rigidbody _rigidbody;
    private Vector3 _wishVelocity;
    
    
    public virtual void Move()
    {
        Debug.Log("Player movement");
    }

    public virtual void TakeDamage(float damage)
    {
        Debug.Log($"{characterName} damaged {damage}");
        health -= damage;
    }
}
