using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Sensor : MonoBehaviour
{
    [SerializeField] private bool _grounded;

    public bool Grounded()
    {
        return _grounded;
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        _grounded = false;
    }
   
}
