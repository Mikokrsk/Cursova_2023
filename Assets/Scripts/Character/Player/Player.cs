using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [Header("Alive")]
    [SerializeField] public HealthSystem healthSystem;
    [Header("Attack")]
    [SerializeField] public float attack1Delay;
    [SerializeField] public int damageAttack1;
    [SerializeField] public float attack2Delay;
    [SerializeField] public int damageAttack2;
    [SerializeField] public float attack3Delay;
    [SerializeField] public int damageAttack3;
    [Header("Colliders")]
    [SerializeField] public Collider2D collider2D;
    [Header("Stats")]
    [SerializeField] public bool isStunned = false;
    [SerializeField] public bool grounded = true;
    [SerializeField] public bool isAlive = true;
    [SerializeField] public bool isMove = false;
    [SerializeField] public bool isAttack = false;
    [Header("Controll Key")]
    [SerializeField] public KeyCode attack1KeyCode = KeyCode.Alpha1;
    [SerializeField] public KeyCode attack2KeyCode = KeyCode.Alpha2;
    [SerializeField] public KeyCode attack3KeyCode = KeyCode.Alpha3;
    [SerializeField] public KeyCode jumpKeyCode = KeyCode.Space;
    [Header("Components")]
    [SerializeField] public PlayerAnimationController _animController;
    [SerializeField] public PlayerGroundSensor _groundSensor;
    [SerializeField] public PlayerMoveController _moveController;
    public CombatController combatController;
    [Header("Events")]
    public Action jump;
    public Action startMove;
    public Action endMove;
    public Action attack1;
    public Action attack2;
    public Action attack3;
}