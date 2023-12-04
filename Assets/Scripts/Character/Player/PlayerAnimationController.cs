using System;
using System.Collections;
using System.Collections.Generic;
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
        _player._playerStats = _player._playerStats;
        if (_player != null)
        {
            _player.startMove += StartMove;
            _player.endMove += EndMove;
            _player.jump += Jump;
            _player.attack1 += Attack1;
            _player.attack2 += Attack2;
            _player.attack3 += Attack3;
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
        Debug.Log("Attack1");
        _player._playerStats.animator.SetTrigger(_player._playerStats.animAttack1Name);
        _player._playerStats.isAttack = true;
        StartCoroutine(AttackDelay(3f));
    }
    public void Attack2()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animAttack2Name);
        StartCoroutine(AttackDelay(3f));
    }
    public void Attack3()
    {
        _player._playerStats.animator.SetTrigger(_player._playerStats.animAttack3Name);
        StartCoroutine(AttackDelay(3f));
    }

    IEnumerator AttackDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _player._playerStats.isAttack = false;
        /* int currentStateHash = _player._playerStats.animator.GetCurrentAnimatorStateInfo(0).fullPathHash;

         string currentStateName = Animator.StringToHash(currentStateHash.ToString()).ToString();
         string currentStateName2 = _player._playerStats.animator.GetCurrentAnimatorStateInfo(0).shortNameHash.ToString();
         Debug.Log(currentStateName2);
         if (currentStateName != animName)
         {
             yield return new WaitForSeconds(1f);
             Debug.Log("IF");
             StartCoroutine(AttackDelay(animName));
         }
         else
         {
             Debug.Log("ELSE");
             _player._playerStats.isAttack = false;
             StopCoroutine(AttackDelay(animName));
         }*/
    }
}
