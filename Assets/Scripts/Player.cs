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
    //[SerializeField] private float normalSpeed;
    //[SerializeField] private float startSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private ConstantForce2D constantForce2D;
    [SerializeField] private float rbVelosityMagnityde;
    [SerializeField] private float rbVelosityMagnitydeX;
    [SerializeField] private float rbVelosityMagnitydeY;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isGroundedBox;
   // [SerializeField] private float distToGround;
    [SerializeField] private Collider2D collider2D;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        constantForce2D = GetComponent<ConstantForce2D>();
        playerAnimator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        speed = maxSpeed;
     //   distToGround = collider2D.bounds.extents.y;
/*        if (IsGrounded() )
        {
            Debug.Log("111111");
        }
        else
        {
            Debug.Log("2222");
        }*/
    }

    void Update()
    {
        Profiler.BeginSample("Player Update");

        // isGrounded = IsGrounded();
        if (  isGroundedBox )
        {
            playerAnimator.SetFloat("AirSpeedY", rbVelosityMagnitydeY);
            playerAnimator.SetBool("Grounded", true);
        }
        else
        {
            playerAnimator.SetBool("Grounded",false);
        }

        

        horizontal = Input.GetAxis("Horizontal");
       
        // vertical = Input.GetAxis("Vertical");
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
            playerAnimator.SetTrigger("Jump");
        }
        
        
        Profiler.EndSample();
    }

    private void Jump()
    {
        Profiler.BeginSample("Player Jump");
        
        rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
        
        Profiler.EndSample();
    }

    private void Move()
    {
        Profiler.BeginSample("Player Move");



        //var horizontal = Input.GetAxis("Horizontal");
        // var direction = horizontal >0 ? horizontal*2 : -horizontal*2;
        var direction = horizontal > 0 ? 1 : -1;
       // var speedX = horizontal != 0 ? 1 : 0;
        
        this.gameObject.transform.localScale = new Vector2(direction,1);
       // var direction = horizontal < 0.5f && horizontal>0 ? 0.5f : -0.5f;
        var vectorForce = new Vector2(direction * speed, 0);
        constantForce2D.force = vectorForce;

        /*var vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();*/
        /*
                if (rb.velocity.magnitude <= 0)
                {
                    rb.velocity += Vector2.right * startSpeed * horizontal * speed;
                }*/

        //rb.transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);

        /*if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity += Vector2.right * horizontal * speed * Time.deltaTime;
        }*/

        Profiler.EndSample();
    }

    public void GetHit(int damage)
    {
        health -= damage;

        //transform.position = Vector2.zero;
        StartCoroutine(GetHitDelay());
        if (health <= 0)
        {
            Debug.Log("die");
        }
    }

    IEnumerator GetHitDelay()
    {
        var normalSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(0.25f);
        speed = normalSpeed;
    }
    /*bool IsGrounded()
    {
        return rb.velocity.y == 0 ? isGrounded = true :isGrounded = false;
    }*/
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        isGroundedBox = true;
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGroundedBox = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGroundedBox = true;
    }
}