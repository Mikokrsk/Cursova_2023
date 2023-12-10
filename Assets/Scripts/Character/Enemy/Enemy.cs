using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats _enemyStats;

    private void Start()
    {
        _enemyStats = GetComponent<EnemyStats>();
    }
    private void Update()
    {
        if(_enemyStats.Health<=0)
        {
            Death();
        }
    }
    public virtual void GetHit(int damage)
    { 
        _enemyStats.Health -= damage;
        Debug.Log($"Bandit Get Hit :{_enemyStats.Health}  Damage :{damage}");
    }
    public virtual void Death() 
    {
        Destroy(gameObject);
    }
}
