using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int _health = 100;
    [SerializeField] protected int _maxHealth = 100;
    public virtual int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    public virtual int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    protected virtual void UpdateHpBar()
    {
        GameUI.Instance.SetHealthValue(_health / (float)_maxHealth);
    }
    public virtual void GetHit(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
        UpdateHpBar();
    }
    public virtual void Heal(int heal)
    {
        _health = Mathf.Clamp(_health + heal, 0, _maxHealth);
        UpdateHpBar();
    }
}