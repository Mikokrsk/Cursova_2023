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
    [SerializeField] private Player _player;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public PlayerGroundSensor playerGroundSensor;
    [Header("Move")]
    [SerializeField] private InputAction MoveAction;
    [SerializeField] private float horizontal;
    [SerializeField] private bool _isMoving = false;
    [SerializeField] public float speedForce = 18f;
    [Header("Jump")]
    [SerializeField] private InputAction JumpAction;
    [SerializeField] public float jumpForce = 18f;
    public bool isJumping = false;

    private void Start()
    {
        MoveAction.Enable();
        JumpAction.Enable();
        JumpAction.performed += Jump;
    }

    void Update()
    {
        horizontal = MoveAction.ReadValue<float>();

        if (horizontal != 0)
        {
            _isMoving = true;
            _player._animController.StartMove();
        }
        else
        {
            _isMoving = false;
            _player._animController.EndMove();
        }
        if (playerGroundSensor.Grounded())
        {
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {
        if (_isMoving)
        {
            Vector2 moveVector = new Vector2(horizontal * speedForce, 0);
            rb.AddForce(moveVector);
            _player.transform.localScale = new Vector3(horizontal, 1, 1);
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // _player.jump?.Invoke();
            _player._animController.Jump();
            isJumping = true;
        }
    }
}
