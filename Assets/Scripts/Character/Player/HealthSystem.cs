using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            ChangeHp(0);
        }
    }
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
            ChangeHp(0);
        }
    }
    public void ChangeHp(int amount)
    {
        _health = Mathf.Clamp(_health + amount, 0, _maxHealth);
        GameUI.Instance.SetHealthValue(_health / (float)_maxHealth);
    }
}