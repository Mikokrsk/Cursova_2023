using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private ConstantForce2D _constantForce2D;
    [SerializeField] private float _rbVelosityMagnityde;
    [SerializeField] private float _rbVelosityMagnitydeX;
    [SerializeField] private float _rbVelosityMagnitydeY;
    [SerializeField] private float _horizontal;
    [SerializeField] private float _vertical;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private bool _isStunned;
    [SerializeField] private bool _isAlive;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private Ground_Sensor _ground_Sensor;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _constantForce2D = GetComponent<ConstantForce2D>();
        _playerAnimator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _ground_Sensor = GetComponentInChildren<Ground_Sensor>();
        _isStunned = false;
        _isAlive = true;
    }

    void Update()
    {
        Profiler.BeginSample("Player Update");
        if (_isStunned || !_isAlive)
        {
            return;
        } 
        if (_ground_Sensor.Grounded())          
        {
            _playerAnimator.SetBool("Grounded", true);
        }
        else
        {
            _playerAnimator.SetBool("Grounded", false);
        }

        _horizontal = Input.GetAxis("Horizontal");

        _rbVelosityMagnityde = _rb.velocity.magnitude;
        _rbVelosityMagnitydeX = _rb.velocity.x;
        _rbVelosityMagnitydeY = _rb.velocity.y;
        _playerAnimator.SetFloat("AirSpeedY", _rbVelosityMagnitydeY);

        if (_horizontal != 0)
        {
            Move();
            _playerAnimator.SetBool("Move", true);
        }
        else
        {
            _playerAnimator.SetBool("Move", false);
            _constantForce2D.force = Vector2.zero;
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
            _playerAnimator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _playerAnimator.SetTrigger("Attack2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _playerAnimator.SetTrigger("Attack3");
        }
        Profiler.EndSample();
    }

    private void Jump()
    {
        Profiler.BeginSample("Player Jump");
        _playerAnimator.SetTrigger("Jump");

        _rb.AddForce(Vector2.up * _jumpForse, ForceMode2D.Impulse);

        Profiler.EndSample();
    }

    private void Move()
    {
        Profiler.BeginSample("Player Move");

        var direction = _horizontal > 0 ? 1 : -1;

        this.gameObject.transform.localScale = new Vector2(direction, 1);

        var vectorForce = new Vector2(direction * _speed, 0);
        _constantForce2D.force = vectorForce;

        Profiler.EndSample();
    }

    public void GetHit(int damage)
    {
        _isStunned = true;
        _health -= damage;

        _constantForce2D.force = Vector2.zero;

        if (_health <= 0)
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
        _isAlive = false;
        _playerAnimator.SetTrigger("Death");
    }

    IEnumerator GetHitDelay()
    {
        
        _playerAnimator.SetTrigger("Hit");
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (!_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                break;
            }
        }
        _isStunned = false;
    }

}
