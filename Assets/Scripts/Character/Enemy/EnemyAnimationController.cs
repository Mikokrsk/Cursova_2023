using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyStats _enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        if(_enemy == null)
        {
            _enemy = GetComponent<Enemy>();
        }
        _enemyStats = _enemy.GetEnemyStats();
        _enemyStats.attack += Attack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        _enemyStats.animator.SetTrigger(_enemyStats.animAttackName);
    }
}
