using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private InputAction _attack1Action;
    [SerializeField] private Attack_Sensor _attack1Sensor;
    [SerializeField] private InputAction _attack2Action;
    [SerializeField] private Attack_Sensor _attack2Sensor;
    [SerializeField] private InputAction _attack3Action;
    [SerializeField] private Attack_Sensor _attack3Sensor;

    private void OnEnable()
    {
        _attack1Action.Enable();
        _attack2Action.Enable();
        _attack3Action.Enable();
        _attack1Action.performed += Attack1;
        _attack2Action.performed += Attack2;
        _attack3Action.performed += Attack3;
    }
    private void OnDisable()
    {
        _attack1Action.Disable();
        _attack2Action.Disable();
        _attack3Action.Disable();
        _attack1Action.performed -= Attack1;
        _attack2Action.performed -= Attack2;
        _attack3Action.performed -= Attack3;
    }

    public void Attack1(InputAction.CallbackContext context)
    {
        if (_attack1Sensor.enabled == false && _player.isAttacking == false)
        {
            _player._animController.Attack1();
            _attack1Sensor.enabled = true;
        }
    }
    public void Attack2(InputAction.CallbackContext context)
    {
        if (_attack2Sensor.enabled == false && _player.isAttacking == false)
        {
            _player._animController.Attack2();
            _attack2Sensor.enabled = true;
        }
    }
    public void Attack3(InputAction.CallbackContext context)
    {
        if (_attack3Sensor.enabled == false && _player.isAttacking == false)
        {
            _player._animController.Attack3();
            _attack3Sensor.enabled = true;
        }
    }
}