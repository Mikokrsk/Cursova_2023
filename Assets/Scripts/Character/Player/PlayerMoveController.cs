using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        if (_player != null)
        {
            _player.startMove += StartMove;
            _player.endMove += EndMove;
            _player.jump += Jump;
        }
    }

    void Update()
    {
        Profiler.BeginSample("PlayerMoveController Update");

        Profiler.EndSample();
    }

    public void Jump()
    {
        Profiler.BeginSample("PlayerMoveController Jump");

        _player._playerStats.rb.AddForce(Vector2.up * _player._playerStats.jumpForse, ForceMode2D.Impulse);

        Profiler.EndSample();
    }

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
    }
}
