using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyAttackZone _enemyAttackingZone;
    [SerializeField] private float _afterAttackDelay;

    private void Update()
    {
        if (_enemy.isAttacking == true)
        {
            return;
        }

        if (_enemyAttackingZone.isPlayerInAttackingZone())
        {
            if (_afterAttackDelay <= 0)
            {
                _enemy.animationController.Attack();
                _afterAttackDelay = _enemyAttackingZone.afterAttackDelay;
            }
            _enemy.isAgresive = true;
        }
        else
        {
            _enemy.isAgresive = false;
        }

        if (_afterAttackDelay > 0)
        {
            _afterAttackDelay -= Time.deltaTime;
        }
    }
}