using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sensor : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D _attack1Colider;
    [SerializeField] private EdgeCollider2D _attack2Colider;
    [SerializeField] private EdgeCollider2D _attack3Colider;
    [SerializeField] private int _damage = 0;

    private void OffColiders()
    {
        _attack1Colider.enabled = false;
        _attack2Colider.enabled = false;
        _attack3Colider.enabled = false;
    }

    public void EnableAttack1Collider()
    {
        _attack1Colider.enabled = true;
        _attack2Colider.enabled = false;
        _attack3Colider.enabled = false;
    }
    public void EnableAttack2Collider()
    {
        _attack1Colider.enabled = false;
        _attack2Colider.enabled = true;
        _attack3Colider.enabled = false;
    }
    public void EnableAttack3Collider()
    {
        _attack1Colider.enabled = false;
        _attack2Colider.enabled = false;
        _attack3Colider.enabled = true;
    }
    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GetHit(_damage);
        }
        OffColiders();
    }
}
