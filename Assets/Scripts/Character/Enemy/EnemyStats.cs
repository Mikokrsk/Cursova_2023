using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [Header("Move")]
    [SerializeField] public float speed = 18f;
    [SerializeField] public ConstantForce2D constantForce2D;
    [SerializeField] public int direction;
    [Header("Stans")]
    [SerializeField] public bool isMove;
    [SerializeField] public bool isPatrolling;
    [SerializeField] public bool isAttaking;
    [Header("Events")]
    public Action jump;
    public Action startMove;
    public Action endMove;
    public Action attack;
    [Header("Combat")]
    public int[] damage = { 10 };
    [Header("Animations")]
    [SerializeField] public Animator animator;
    public string animAttackName = "Attack";

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
}
