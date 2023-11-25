using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForse;
    [SerializeField] private ConstantForce2D constantForce2D;
    [SerializeField] private float rbVelosityMagnityde;
    [SerializeField] private float rbVelosityMagnitydeX;
    [SerializeField] private float rbVelosityMagnitydeY;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private bool isStunned;
    [SerializeField] private bool isAlive;
   // [SerializeField] private bool isGrounded;
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private Ground_Sensor m_Ground_Sensor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        constantForce2D = GetComponent<ConstantForce2D>();
        playerAnimator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        m_Ground_Sensor = GetComponentInChildren<Ground_Sensor>();
        isStunned = false;
        isAlive = true;
    }

    void Update()
    {
        Profiler.BeginSample("Player Update");
        if (isStunned || !isAlive)
        {
            return;
        } 
        if (m_Ground_Sensor.Grounded())          
        {
            playerAnimator.SetBool("Grounded", true);
        }
        else
        {
            playerAnimator.SetBool("Grounded", false);
        }



        horizontal = Input.GetAxis("Horizontal");

        rbVelosityMagnityde = rb.velocity.magnitude;
        rbVelosityMagnitydeX = rb.velocity.x;
        rbVelosityMagnitydeY = rb.velocity.y;
        playerAnimator.SetFloat("AirSpeedY", rbVelosityMagnitydeY);

        if (horizontal != 0)
        {
            Move();
            playerAnimator.SetBool("Move", true);
        }
        else
        {
            playerAnimator.SetBool("Move", false);
            constantForce2D.force = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetHit(25);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAnimator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerAnimator.SetTrigger("Attack2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerAnimator.SetTrigger("Attack3");
        }
        Profiler.EndSample();
    }

    private void Jump()
    {
        Profiler.BeginSample("Player Jump");
        playerAnimator.SetTrigger("Jump");

        rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);

        Profiler.EndSample();
    }

    private void Move()
    {
        Profiler.BeginSample("Player Move");

        var direction = horizontal > 0 ? 1 : -1;

        this.gameObject.transform.localScale = new Vector2(direction, 1);

        var vectorForce = new Vector2(direction * speed, 0);
        constantForce2D.force = vectorForce;

        Profiler.EndSample();
    }

    public void GetHit(int damage)
    {
        isStunned = true;
        health -= damage;

        constantForce2D.force = Vector2.zero;

        if (health <= 0)
        {
            Death();
        }
        else
        {
            StartCoroutine(GetHitDelay());
        }

    }
    public void Death()
    {
        Debug.Log("die");
        isAlive = false;
        playerAnimator.SetTrigger("Death");
    }

    IEnumerator GetHitDelay()
    {
        
        playerAnimator.SetTrigger("Hit");
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                break;
            }
        }
        isStunned = false;
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }*/
}
