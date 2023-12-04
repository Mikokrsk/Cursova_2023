using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats _enemyStats;

    public virtual void GetHit(int damage)
    { 
        _enemyStats.Health -= damage;
    }
}
