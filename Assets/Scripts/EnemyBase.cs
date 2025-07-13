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
    // 当前状态
    public EnemyState currentState = EnemyState.Patrol;

    public virtual void Start()
    {
        Debug.Log("EnemyBase Start");
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