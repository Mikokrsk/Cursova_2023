using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerGroundSensor : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _boxCollider;
    [SerializeField] private Vector2 _sizeBox;
    [SerializeField] private float _range;
   
    private void OnEnable()
    {
        _player = GetComponent<Player>();
       // _player.SetPlayerGroundSensor(this);
    }

    public bool Grounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider.bounds.center
            +transform.up *_range,_sizeBox, 0, Vector2.down, 0);
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_boxCollider.bounds.center + transform.up * _range
            , _sizeBox);
    }
}
