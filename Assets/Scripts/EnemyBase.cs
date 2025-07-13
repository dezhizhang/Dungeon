using System;
using UnityEngine;

/// <summary>
/// 怪物公共方法
/// </summary>
public enum EnemyState
{
    Patrol, // 巡逻状态
    Pursuit, // 所击状态
    Attack, // 攻击
    GetHit, // 受伤
    Death, // 死亡
}


public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Move")] 
    public Transform left;

    public Transform right;

    // 怪物移动方向
    public bool isRight = false;

    // 怪物移动的速度
    public float speed = 1f;

    // 添加刚体
    public Rigidbody2D rb;

    // 当前状态
    [HideInInspector] public EnemyState currentState = EnemyState.Patrol;

    public virtual void Start()
    {
        PatrolEnter();
    }

    public void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                PatrolUpdate();
                break;
            case EnemyState.Pursuit:
                PursuitUpdate();
                break;
            case EnemyState.Attack:
                AttackUpdate();
                break;
            case EnemyState.GetHit:
                GetHitUpdate();
                break;
            case EnemyState.Death:
                DeathUpdate();
                break;
        }
    }

    public virtual void FixedUpdate()
    {
    }

    #region 状态机

    public virtual void PatrolEnter()
    {
    }

    public virtual void PatrolUpdate()
    {
    }

    public virtual void PatrolExit()
    {
    }


    public virtual void PursuitEnter()
    {
    }

    public virtual void PursuitUpdate()
    {
    }

    public virtual void PursuitExit()
    {
    }

    public virtual void AttackEnter()
    {
    }

    public virtual void AttackUpdate()
    {
    }

    public virtual void AttackExit()
    {
    }

    public virtual void GetHitEnter()
    {
    }

    public virtual void GetHitUpdate()
    {
    }

    public virtual void GetHitExit()
    {
    }

    public virtual void DeathEnter()
    {
    }

    public virtual void DeathUpdate()
    {
    }

    public virtual void DeathExit()
    {
    }

    #endregion

    // 态态机切换
    public virtual void ChangeCurState(EnemyState state)
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                PatrolExit();
                break;
            case EnemyState.Pursuit:
                PursuitExit();
                break;
            case EnemyState.Attack:
                AttackExit();
                break;
            case EnemyState.GetHit:
                GetHitExit();
                break;
            case EnemyState.Death:
                DeathExit();
                break;
        }

        currentState = state;
        switch (state)
        {
            case EnemyState.Patrol:
                PatrolEnter();
                break;
            case EnemyState.Pursuit:
                PursuitEnter();
                break;
            case EnemyState.Attack:
                AttackEnter();
                break;
            case EnemyState.GetHit:
                GetHitEnter();
                break;
            case EnemyState.Death:
                DeathEnter();
                break;
        }
    }
}