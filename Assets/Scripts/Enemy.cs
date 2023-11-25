using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] private float speed;

    public virtual void GetHit(int damage)
    {
        health -= damage;
    }

}
