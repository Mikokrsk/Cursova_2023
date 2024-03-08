using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Player _player;
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
    [SerializeField] public Animator animator;
    [Header("Animations values")]
    [SerializeField] public float rbVelosityMagnityde;
    [SerializeField] public float rbVelosityMagnitydeX;
    [SerializeField] public float rbVelosityMagnitydeY;
    [SerializeField] public float horizontal;
    [SerializeField] public float vertical;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public PlayerGroundSensor playerGroundSensor;
    private void OnEnable()
    {
        _player = GetComponent<Player>();
    }
    void Start()
    {
        // _player._playerStats = _player._playerStats;
        if (_player != null)
        {
            _player.startMove += StartMove;
            _player.endMove += EndMove;
            _player.jump += Jump;
/*            _player.attack1 += Attack1;
            _player.attack2 += Attack2;
            _player.attack3 += Attack3;*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        rbVelosityMagnitydeY = rb.velocity.y;
        animator.SetFloat(animAirSpeedYName, rbVelosityMagnitydeY);
        animator.SetBool(animGroundedName, playerGroundSensor.IsGrounded());
    }
    public void StartMove()
    {
        animator.SetBool(animMoveName, true);
    }
    public void EndMove()
    {
        animator.SetBool(animMoveName, false);
    }
    public void Jump()
    {
        animator.SetTrigger(animJumpName);
    }
    public void Attack1()
    {
        animator.SetTrigger(animAttack1Name);
    }
    public void Attack2()
    {
        animator.SetTrigger(animAttack2Name);
    }
    public void Attack3()
    {
        animator.SetTrigger(animAttack3Name);
    }
    public void Hit()
    {
        animator.SetTrigger(animHitName);
    }
}
