using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [Header("Animations")]
    [SerializeField] public Animator animator;
    public string animAttackName = "Attack";
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
}
