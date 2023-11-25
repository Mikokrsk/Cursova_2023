using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Sensor : MonoBehaviour
{
    [SerializeField] private bool m_Grounded;

    public bool Grounded()
    {
        return m_Grounded;
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_Grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        m_Grounded = false;
    }
   
}
