using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Controllers")]
    public EnemyMoveController enemyMoveController;
    public EnemyAnimationController animationController;

    [Header("Move")]
    public float speed = 18f;
    public ConstantForce2D constantForce2D;
    public int direction;
    [Header("Stans")]
    public bool isMove;
    public bool isPatrolling;
    public bool isAttacking;
    [Header("Events")]
    public Action jump;
    public Action startMove;
    public Action endMove;
    public Action attack;

    [Header("HealthSystem")]
    [SerializeField] protected int _health = 100;

    public virtual void GetHit(int damage)
    {
        _health -= damage;
        Debug.Log($"Enemy Get Hit :{_health}  Damage :{damage}");
    }
    public virtual void Death()
    {
        Destroy(gameObject);
    }
}