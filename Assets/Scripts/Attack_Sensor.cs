using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sensor : MonoBehaviour
{
    public EdgeCollider2D edgeCollider2D;
    public int damage = 15;
/*    private void OnEnable()
    {
        
    }*/
    // Start is called before the first frame update
    void Start()
    {
        edgeCollider2D = GetComponent<EdgeCollider2D>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GetHit(damage);
        }
    }
}
