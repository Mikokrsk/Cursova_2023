using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class MoveController : MonoBehaviour
{
    /*    [SerializeField] protected Rigidbody2D _rb;
        [SerializeField] protected ConstantForce2D _constantForce2D;
        [SerializeField] protected float _jumpForse;
        [SerializeField] protected float _speed;
        [SerializeField] protected float _horizontal;*//*
    [SerializeField] protected CharacterStats _characterStats;
    private void Start()
    {
        _characterStats = new CharacterStats();
    }
    void Update()
    {
        Profiler.BeginSample("Move Controller");

        _horizontal = Input.GetAxis("Horizontal");


        if (_horizontal != 0)
        {
            Move();
           // _animator.SetBool("Move", true);
        }
        else
        {
            //_animator.SetBool("Move", false);
            _constantForce2D.force = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Profiler.EndSample();
    }

    protected virtual void Jump()
    {
        Profiler.BeginSample("Player Jump");
      //  _animator.SetTrigger(_animjumpName);

        _rb.AddForce(Vector2.up * _jumpForse, ForceMode2D.Impulse);

        Profiler.EndSample();
    }

    protected virtual void Move()
    {
        Profiler.BeginSample("Player Move");

        var direction = _horizontal > 0 ? 1 : -1;

        this.gameObject.transform.localScale = new Vector2(direction, 1);

        var vectorForce = new Vector2(direction * _speed, 0);
        _constantForce2D.force = vectorForce;

        Profiler.EndSample();
    }*/

}
