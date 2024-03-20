using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : HealthSystem
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _enemyTransform;
    private void Awake()
    {
        _healthBarSlider.value = _health;
        _healthBarSlider.maxValue = _maxHealth;
    }
    private void LateUpdate()
    {
        transform.position = _enemyTransform.position;
    }
    protected override void UpdateHpBar()
    {
        _healthBarSlider.value = _health;
    }
    public override void GetHit(int damage)
    {
        _health -= damage;
        UpdateHpBar();
        if (_health <= 0)
        {
            Death();
        }
    }
    public virtual void Death()
    {
        Destroy(_enemy);
    }
}