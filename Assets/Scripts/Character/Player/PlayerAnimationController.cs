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
    // public event Action Moved;
    private void OnEnable()
    {
        _player = GetComponent<Player>();
    }
    void Start()
    {
       // _player._playerStats = _player._playerStats;
        if (_player != null)
        {
            _player._playerStats.startMove += StartMove;
            _player._playerStats.endMove += EndMove;
            _player._playerStats.jump += Jump;
            _player._playerStats.attack1 += Attack1;
            _player._playerStats.attack2 += Attack2;
            _player._playerStats.attack3 += Attack3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _player._playerStats.animator.SetFloat(_player._playerStats.animAirSpeedYName, _player._playerStats.rbVelosityMagnitydeY);
        _player._playerStats.animator.SetBool(_player._playerStats.animGroundedName, _player._playerStats.grounded);
    }
    public void StartMove()
    {
        _player._playerStats.animator.SetBool(_player._playerStats.animMoveName, true);
    }
    public void EndMove()
    {
        _player._playerStats.animator.SetBool(_player._playerStats.animMoveName, false);
    }
    public void Jump()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animJumpName);
    }
    public void Attack1()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animAttack1Name);
    }
    public void Attack2()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animAttack2Name);
    }
    public void Attack3()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animAttack3Name);
    }
    public void Hit()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animHitName);
    }
}
