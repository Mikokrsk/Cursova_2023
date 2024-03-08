using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private Collider2D _enemyCollider;
    [SerializeField] private Vector2 _sizeBox;
    [SerializeField] private float _horizontalRange;
    [SerializeField] private float _verticalRange;

    public float afterAttackDelay;
    public bool isPlayerInAttackingZone()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_enemyCollider.bounds.center
            + transform.right * _horizontalRange + transform.up * _verticalRange, _sizeBox, 0, Vector2.right, 0);
        if (hit.collider == null)
        {
            return false;
        }
        return hit.collider.CompareTag("Player");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_enemyCollider.bounds.center
            + transform.right * _horizontalRange + transform.up * _verticalRange, _sizeBox);
    }
}