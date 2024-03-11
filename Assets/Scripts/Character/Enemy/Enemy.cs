using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Controllers")]
    public EnemyMoveController enemyMoveController;
    public EnemyAnimationController animationController;
    public PlayerGroundSensor groundSensor;
    public EnemyHealthController healthController;
    [Header("Move")]
    public Rigidbody2D rb;
    // public float speed = 18f;

    [Header("Stans")]
    public bool isRuning;
    public bool isPatrolling;
    public bool isAttacking;
    public bool isJumping;
    public bool isGrounded;

    public virtual void GetHit(int damage)
    {
        healthController.GetHit(damage);
    }
}