using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sensor : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        OnAttackCollider();
    }

    private void OnDisable()
    {
        OffAttackCollider();
        _player.isAttacking = false;
    }

    public void OffAttackCollider()
    {
        _collider.enabled = false;
    }

    public void OnAttackCollider()
    {
        _player.isAttacking = true;
        _collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GetHit(_damage);

        }
        OffAttackCollider();
    }
}