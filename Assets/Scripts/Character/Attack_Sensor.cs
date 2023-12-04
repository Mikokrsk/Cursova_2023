using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sensor : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D _edgeCollider2D;
    [SerializeField] private int _damage = 15;

    // Start is called before the first frame update
    void Start()
    {
        _edgeCollider2D = GetComponent<EdgeCollider2D>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GetHit(_damage);
        }
    }
}
