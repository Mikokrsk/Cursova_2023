using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Attack_Sensor _attackSensor;
    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _attackSensor = GetComponentInChildren<Attack_Sensor>();
    }
    void Start()
    {
        if (_player != null)
        {
            _player._playerStats.attack1 += Attack1;
            _player._playerStats.attack2 += Attack2;
            _player._playerStats.attack3 += Attack3;
        }
    }

    void Update()
    {
        //Attack
        if (_player._playerStats.isAttack)
        {
            return;
        }
        if (Input.GetKeyDown(_player._playerStats.attack1KeyCode))
        {
            _player._playerStats.attack1.Invoke();
        }
        if (Input.GetKeyDown(_player._playerStats.attack2KeyCode))
        {
            _player._playerStats.attack2.Invoke();
        }
        if (Input.GetKeyDown(_player._playerStats.attack3KeyCode))
        {
            _player._playerStats.attack3.Invoke();
        }
    }
    public void Attack1()
    {
        _attackSensor.SetDamage(_player._playerStats.damageAttack1);
        _attackSensor.EnableAttack1Collider();

        StartCoroutine(Attack(_player._playerStats.attack1Delay));
    }
    public void Attack2()
    {
        _attackSensor.SetDamage(_player._playerStats.damageAttack2);
        _attackSensor.EnableAttack2Collider();
        StartCoroutine(Attack(_player._playerStats.attack2Delay));
    }
    public void Attack3()
    {
        _attackSensor.SetDamage(_player._playerStats.damageAttack3);
        _attackSensor.EnableAttack3Collider();
        StartCoroutine(Attack(_player._playerStats.attack3Delay));
    }
    private IEnumerator Attack(float attackDelay)
    {
        _player._playerStats.isAttack = true;
        yield return new WaitForSeconds(attackDelay);
        _player._playerStats.isAttack = false;
    }
}
