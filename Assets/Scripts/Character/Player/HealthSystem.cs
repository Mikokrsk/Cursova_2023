using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        }
    }
    public void UpdateHpBar()
    {
        GameUI.Instance.SetHealthValue(_health / (float)_maxHealth);
    }
    public void GetHit(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
        UpdateHpBar();
    }
    public void Heal(int heal) 
    {
        _health = Mathf.Clamp(_health + heal, 0, _maxHealth);
        UpdateHpBar();
    }
}