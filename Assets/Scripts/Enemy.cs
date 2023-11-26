using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] private float _speed;

    public virtual void GetHit(int damage)
    {
        _health -= damage;
    }

}
