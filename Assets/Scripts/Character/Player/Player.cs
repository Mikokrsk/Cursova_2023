using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerStats _playerStats;
    public event Action startMove;
    public event Action endMove;
    public event Action jump;
    public event Action attack1;
    public event Action attack2;
    public event Action attack3;
    private void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerStats.constantForce2D = GetComponent<ConstantForce2D>();
        _playerStats.animator = GetComponent<Animator>();
        _playerStats.collider2D = GetComponent<Collider2D>();
        _playerStats.ground_Sensor = GetComponent<PlayerGroundSensor>();
        _playerStats.rb = GetComponent<Rigidbody2D>();
        //_groundSensor = GetComponent<PlayerGroundSensor>();
        /*       _playerStats = GetComponent<PlayerStats>(); 
                _animController = GetComponent<PlayerAnimationController>();
               
                _moveController = GetComponent<PlayerMoveController>();*/
    }
    private void Update()
    {
        if (_playerStats.isAttack == true)
        {
            return;
        }
        else
        {
            //Attack
            if (Input.GetKeyDown(_playerStats.attack1KeyCode))
            {
                attack1.Invoke();
            }
            if (Input.GetKeyDown(_playerStats.attack2KeyCode))
            {
                attack2.Invoke();
            }
            if (Input.GetKeyDown(_playerStats.attack3KeyCode))
            {
                attack3.Invoke();
            }
            //Move
            _playerStats.horizontal = Input.GetAxis("Horizontal");
            if (_playerStats.horizontal != 0)
            {
                startMove?.Invoke();
            }
            else
            {
                endMove?.Invoke();
            }
            //Jump
            if (Input.GetKeyDown(_playerStats.jumpKeyCode) && _playerStats.grounded)
            {
                jump?.Invoke();
            }
        }
        _playerStats.rbVelosityMagnityde = _playerStats.rb.velocity.magnitude;
        _playerStats.rbVelosityMagnitydeX = _playerStats.rb.velocity.x;
        _playerStats.rbVelosityMagnitydeY = _playerStats.rb.velocity.y;
        _playerStats.grounded = _playerStats.ground_Sensor.Grounded();
    }
    /*    public void SetPlayerStats(PlayerStats playerStats)
        {
            _playerStats = playerStats;
        }
        public PlayerStats GetPlayerStats()
        {
            return _playerStats;
        }
        public PlayerAnimationController GetPlayerAnimationController()
        {
            return _playerStats._animController;
        }
        public void SetPlayerAnimationController(PlayerAnimationController animController)
        {
            _animController = animController;
        }
        public PlayerGroundSensor GetPlayerGroundSensor()
        {
            return _groundSensor;
        }
        public void SetPlayerGroundSensor(PlayerGroundSensor groundSensor)
        {
            _groundSensor = groundSensor;
        }
        public PlayerMoveController GetPlayerMoveController()
        {
            return _moveController;
        }
        public void SetPlayerMoveController(PlayerMoveController moveController)
        {
            _moveController = moveController;
        }*/
}