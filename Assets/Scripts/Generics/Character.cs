using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName = "Player Name";
    public float health = 100.0f;
    public float moveSpeed = 5.0f;

    protected Vector3 _wishVelocity;
    protected Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
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
