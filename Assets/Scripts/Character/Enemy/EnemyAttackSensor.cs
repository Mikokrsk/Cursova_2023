using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSensor : Attack_Sensor
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyStats _enemyStats;

    private void Start()
    {
        _enemyStats = _enemy.GetEnemyStats();
    }
    public override void OffAllColiders()
    {
        foreach (var collider in _attackColliders)
        {
            collider.enabled = false;
        }
    }
    public override void EnableAttackCollider(int id)
    {
        _attackColliders[id].enabled = true;
        SetDamage(_attackDamages[id]);
    }

    public override void SetDamage(int damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponentInChildren<HealthSystem>();
        if (player != null)
        {
            player.GetHit(_damage);
        }
        OffAllColiders();
    }
}