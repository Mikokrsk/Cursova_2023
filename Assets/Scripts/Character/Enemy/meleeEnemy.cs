using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private EnemyAttackSensor _attackSensor;

    // Start is called before the first frame update
    void Start()
    {
        _enemyStats = _enemy.GetEnemyStats();
        _enemyStats.attack += Attack;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Attack()
    {
        _enemyStats.isAttaking = true;
        //  _attackSensor.EnableAttackCollider(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*            var player = collision.gameObject.GetComponent<Player>();
                        player.GetHit(_enemy.GetEnemyStats().damage);*/

            //   _enemyStats?.attack.Invoke();
        }
    }

}
