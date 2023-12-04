using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
}
