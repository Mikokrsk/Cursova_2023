using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    private void Start()
    {
        _enemyStats = GetComponent<EnemyStats>();
    }

    public override void GetHit(int damage)
    {
       _enemyStats.Health -= damage;
        Debug.Log($"Bandit Get Hit :{_enemyStats.Health}  Damage :{damage}");
    }
}
