using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Character : MonoBehaviour
{
    protected CharacterStats _characterStats;

    protected virtual void Jump()
    {
        Profiler.BeginSample("Jump");
        Debug.Log("Jump");
        Profiler.EndSample();
    }

    protected virtual void Move()
    {
        Profiler.BeginSample("Move");
        Debug.Log("Move");
        Profiler.EndSample();
    }

    public virtual void GetHit(int damage)
    {
        Profiler.BeginSample("GetHit");
        Debug.Log("GetHit");
        Profiler.EndSample();
    }

    public virtual void Death()
    {
        Profiler.BeginSample("Death");
        Debug.Log("Death");
        Profiler.EndSample();
    }
}
