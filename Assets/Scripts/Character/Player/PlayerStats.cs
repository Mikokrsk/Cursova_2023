using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Alive")]
    [SerializeField] public float health = 100;
    [Header("Move")]
    [SerializeField] public float speed = 18f;
    [SerializeField] public ConstantForce2D constantForce2D;
    [Header("Jump")]
    [SerializeField] public float jumpForse = 10f;
    [Header("Attack")]
    [SerializeField] public float attack1Delay;
    [SerializeField] public int damageAttack1;
    [SerializeField] public float attack2Delay;
    [SerializeField] public int damageAttack2;
    [SerializeField] public float attack3Delay;
    [SerializeField] public int damageAttack3;
    [Header("Animations values")]
    [SerializeField] public Animator animator;
    [SerializeField] public float rbVelosityMagnityde;
    [SerializeField] public float rbVelosityMagnitydeX;
    [SerializeField] public float rbVelosityMagnitydeY;
    [SerializeField] public float horizontal;
    [SerializeField] public float vertical;
    [Header("Colliders")]
    [SerializeField] public Collider2D collider2D;
    [SerializeField] public PlayerGroundSensor ground_Sensor;
    [Header("Rigidbody")]
    [SerializeField] public Rigidbody2D rb;
    [Header("Animations name")]
    [SerializeField] public string animJumpName = "HeroKnight_Jump";
    [SerializeField] public string animMoveName = "HeroKnight_Run";
    [SerializeField] public string animDeathName = "HeroKnight_Death";
    [SerializeField] public string animHitName = "HeroKnight_Hurt";
    [SerializeField] public string animAttack1Name = "HeroKnight_Attack1";
    [SerializeField] public string animAttack2Name = "HeroKnight_Attack2";
    [SerializeField] public string animAttack3Name = "HeroKnight_Attack3";
    [SerializeField] public string animIdleName = "HeroKnight_Idle";
    [SerializeField] public string animAirSpeedYName = "AirSpeedY";
    [SerializeField] public string animGroundedName = "Grounded";
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
    [Header("Events")]
    public Action jump;
    public Action startMove;
    public Action endMove;
    public Action attack1;
    public Action attack2;
    public Action attack3;
}
