using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [Header("Animations")]
    [SerializeField] public Animator animator;
    public string animAttackName = "Attack";
    public string animIsRuningName = "IsRuning";
    public string animIsGroundedName = "IsGrounded";
    // Start is called before the first frame update
    void Start()
    {
        if (_enemy == null)
        {
            _enemy = GetComponent<Enemy>();
        }
    }

    public void Attack()
    {
        animator.SetTrigger(animAttackName);
    }

    private void Update()
    {
        animator.SetBool(animIsRuningName, _enemy.isRuning);
        _enemy.isGrounded = _enemy.groundSensor.IsGrounded();
        animator.SetBool(animIsGroundedName, _enemy.isGrounded);
    }
}
