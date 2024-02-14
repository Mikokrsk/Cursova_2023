using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Profiling;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private InputAction MoveAction;
    [SerializeField] private InputAction JumpAction;
    [SerializeField] private float horizontal;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] private bool _isJumping = false;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float speedForce = 18f;
    [SerializeField] public float jumpForce = 18f;


    private void Start()
    {
        /*                if (_player != null)
                        {
                            _player._playerStats.startMove += StartMove;
                            _player._playerStats.endMove += EndMove;
                            _player._playerStats.jump += Jump;
                        }*/
        MoveAction.Enable();
        JumpAction.Enable();
        JumpAction.performed += Jump;
    }

    void Update()
    {
        /*        Profiler.BeginSample("PlayerMoveController Update");
                _player._playerStats.horizontal = Input.GetAxis("Horizontal");
                if (_player._playerStats.horizontal != 0)
                {
                    _player._playerStats.startMove?.Invoke();
                }
                else
                {
                    _player._playerStats.endMove?.Invoke();
                }
                if (Input.GetKeyDown(_player._playerStats.jumpKeyCode) && _player._playerStats.grounded)
                {
                   _player._playerStats.jump?.Invoke();
                }
                Profiler.EndSample();*/
        horizontal = MoveAction.ReadValue<float>();

        if (horizontal != 0)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }
        /*        if (!Mathf.Approximately(horizontal.x, 0.0f) || !Mathf.Approximately(horizontal.y, 0.0f))
                {
                    moveDirection.Set(horizontal.x, horizontal.y);
                    moveDirection.Normalize();
                }*/
    }
    private void FixedUpdate()
    {
        /*        Vector2 position = (Vector2)rb.position + horizontal * speed * Time.deltaTime;
                rb.MovePosition(position);*/
        if (_isMoving)
        {
            Vector2 moveVector = new Vector2(horizontal * speedForce, 0);
            rb.AddForce(moveVector);
            _player.transform.localScale = new Vector3(horizontal, 1, 1);
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    /*
        public void StartMove()
        {
            Profiler.BeginSample("PlayerMoveController Move");

            var direction = _player._playerStats.horizontal > 0 ? 1 : -1;

            gameObject.transform.localScale = new Vector2(direction, 1);

            var vectorForce = new Vector2(direction * _player._playerStats.speed, 0);
            _player._playerStats.constantForce2D.force = vectorForce;
            Profiler.EndSample();
        }

        public void EndMove()
        {
            _player._playerStats.constantForce2D.force = Vector2.zero;
        }*/
}
