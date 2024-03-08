using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.InputSystem;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private float _speedForce;
    //[SerializeField] private float _jumpForce;
    [SerializeField] private Enemy _enemy;

    void Update()
    {
        if (_enemy.isPatrolling)
        {
            Patrolling();
            _enemy.isRuning = true;
            return;
        }
        else
        {
            _enemy.isRuning = false;
        }
    }

    private void Patrolling()
    {
        if (_enemy.transform.position.x <= _leftBorder.position.x)
        {
            _enemy.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            if (_enemy.transform.position.x >= _rightBorder.position.x)
            {
                _enemy.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        _enemy.transform.Translate(Vector2.left * _speedForce * Time.deltaTime);
    }

    /*    private void Jump()
        {
            if (!_enemy.isJumping)
            {
                _enemy.rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _enemy.isJumping = true;
            }
        }*/
}
