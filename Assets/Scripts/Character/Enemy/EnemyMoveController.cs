using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMoveController : MonoBehaviour
{
    //[SerializeField] private int _leftBorderX;
    //[SerializeField] private int _rightBorderX;
    [SerializeField] private Transform _leftBorderX;
    [SerializeField] private Transform _rightBorderX;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyStats _enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.SetEnemyMoveController(this);
        _enemyStats = _enemy.GetEnemyStats();
        if (_leftBorderX.position.x > _rightBorderX.position.x)
        {
            var rightBorderX = _leftBorderX;
            _leftBorderX = _rightBorderX;
            _rightBorderX = rightBorderX;
        }

        if (_enemyStats == null)
        {
            gameObject.AddComponent<EnemyStats>();
            _enemyStats = GetComponent<EnemyStats>();
        }
        if (_enemyStats.constantForce2D == null)
        {
            gameObject.AddComponent<ConstantForce2D>();
            _enemyStats.constantForce2D = GetComponent<ConstantForce2D>();
        }

        _enemyStats.startMove += StartMove;
        _enemyStats.endMove += EndMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyStats.isPatrolling)
        {
            Patrolling();
            return;
        }

        EndMove();
    }

    private void Patrolling()
    {
        var range = (_rightBorderX.position.x - _leftBorderX.position.x) / 7;
        if (transform.position.x - range < _leftBorderX.position.x)
        {
            _enemyStats.direction = 1;
        }
        if (transform.position.x + range > _rightBorderX.position.x)
        {
            _enemyStats.direction = -1;
        }
        _enemyStats.startMove?.Invoke();

    }

    public void StartMove()
    {
        _enemyStats.constantForce2D.enabled = true;
        _enemyStats.direction = _enemyStats.direction > 0 ? 1 : -1;
        gameObject.transform.localScale = new Vector2(-_enemyStats.direction, 1);

        var vectorForce = new Vector2(_enemyStats.direction * _enemyStats.speed, 0);
        _enemyStats.constantForce2D.force = vectorForce;
    }
    public void EndMove()
    {
        _enemyStats.constantForce2D.force = new Vector2(0, _enemyStats.constantForce2D.force.y);
    }
}
