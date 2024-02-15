using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Attack_Sensor _attackSensor;
    public bool isAttacking = false;
    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _attackSensor = GetComponentInChildren<Attack_Sensor>();
    }
    void Start()
    {
        if (_player != null)
        {
            _player.attack1 += Attack1;
            _player.attack2 += Attack2;
            _player.attack3 += Attack3;
        }
    }

    void Update()
    {
        //Attack
        if (isAttacking)
        {
            return;
        }
        if (Input.GetKeyDown(_player.attack1KeyCode))
        {
            _player.attack1.Invoke();
        }
        if (Input.GetKeyDown(_player.attack2KeyCode))
        {
            _player.attack2.Invoke();
        }
        if (Input.GetKeyDown(_player.attack3KeyCode))
        {
            _player.attack3.Invoke();
        }
    }
    public void Attack1()
    {
        _attackSensor.SetDamage(_player.damageAttack1);
        _attackSensor.EnableAttack1Collider();
        StartCoroutine(Attack(_player.attack1Delay));
    }
    public void Attack2()
    {
        _attackSensor.SetDamage(_player.damageAttack2);
        _attackSensor.EnableAttack2Collider();
        StartCoroutine(Attack(_player.attack2Delay));
    }
    public void Attack3()
    {
        _attackSensor.SetDamage(_player.damageAttack3);
        _attackSensor.EnableAttack3Collider();
        StartCoroutine(Attack(_player.attack3Delay));
    }
    private IEnumerator Attack(float attackDelay)
    {
        _player.isAttack = true;
        yield return new WaitForSeconds(attackDelay);
        _player.isAttack = false;
        _attackSensor.OffAllColiders();
    }

}
