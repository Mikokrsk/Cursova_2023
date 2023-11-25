using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    private void OnEnable()
    {
        health = 100;
    }

    public override void GetHit(int damage)
    {
        health -= damage;
        Debug.Log($"Bandit Get Hit :{health}  Damage :{damage}");
    }
}
