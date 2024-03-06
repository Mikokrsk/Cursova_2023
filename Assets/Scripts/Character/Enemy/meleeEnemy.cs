using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyAttackSensor _enemyAttackSensor1;
    [SerializeField] private Collider2D _enemyCollider;
    [SerializeField] private Vector2 _sizeBox;
    [SerializeField] private float _horizontalRange;
    [SerializeField] private float _verticalRange;
    [SerializeField] private float _afterDelay;
    [SerializeField] private float _maxDelay;

    public bool isPlayerInAttackingZone()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_enemyCollider.bounds.center
            + transform.right * _horizontalRange + transform.up * _verticalRange, _sizeBox, 0, Vector2.right, 0);
        return hit.collider.tag == "Player";
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_enemyCollider.bounds.center
            + transform.right * _horizontalRange + transform.up * _verticalRange, _sizeBox);
    }

    private void Update()
    {
        if (_enemy.isAttacking == true)
        {
            return;
        }
        if (isPlayerInAttackingZone() && _afterDelay <= 0)
        {
            _enemy.animationController.Attack();
            _afterDelay = _maxDelay;
        }
        if (_afterDelay >= 0)
        {
            _afterDelay -= Time.deltaTime;
        }
    }

}