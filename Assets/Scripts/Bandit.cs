using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    private void OnEnable()
    {
        _health = 100;
    }

    public override void GetHit(int damage)
    {
        _health -= damage;
        Debug.Log($"Bandit Get Hit :{_health}  Damage :{damage}");
    }
}
