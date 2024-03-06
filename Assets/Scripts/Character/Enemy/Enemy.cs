using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats _enemyStats;
    [SerializeField] protected EnemyMoveController _enemyMoveController;
    [Header("Stats")]
    [SerializeField] public bool isAttacking;
    [SerializeField] public EnemyAnimationController animationController;


    public EnemyStats GetEnemyStats()
    {
        return _enemyStats;
    }
    public void SetEnemyStats(EnemyStats enemyStats)
    {
        _enemyStats = enemyStats;
    }
    public EnemyMoveController GetEnemyMoveController()
    {
        return _enemyMoveController;
    }
    public void SetEnemyMoveController(EnemyMoveController enemyMoveController)
    {
        _enemyMoveController = enemyMoveController;
    }
    /*    private  void Start()
        {
            _enemyStats = GetComponent<EnemyStats>();
        }
        private void Update()
        {
            if(_enemyStats.Health<=0)
            {
                Death();
            }
        }*/
    public virtual void GetHit(int damage)
    {
        _enemyStats.Health -= damage;
        Debug.Log($"Enemy Get Hit :{_enemyStats.Health}  Damage :{damage}");
    }
    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
