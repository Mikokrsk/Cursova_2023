using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        OnAttackCollider();
    }

    private void OnDisable()
    {
        OffAttackCollider();
        _enemy.isAttacking = false;
    }

    public void OffAttackCollider()
    {
        _collider.enabled = false;
    }

    public void OnAttackCollider()
    {
        _collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.healthSystem.GetHit(_damage);
        }
        OffAttackCollider();
    }
}