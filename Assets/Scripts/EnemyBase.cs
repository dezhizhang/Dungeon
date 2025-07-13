using System;
using UnityEngine;

/// <summary>
/// 怪物公共方法
/// </summary>
public enum EnemyState
{
    Idle, // 静态状态
    Patrol, // 巡逻状态
    Pursuit, // 所击状态
    Attack, // 攻击
    GetHit, // 受伤
    Death, // 死亡
}


public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Idle")]
    // 等持动画时间
    public float idleTime = 2f;

    public SpriteRenderer spriteRenderer;

    public Animator enemyAnimator;


    [Header("Enemy Patrol")]

    // 当前状态
    public EnemyState currentState = EnemyState.Patrol;

    public Transform left;

    public Transform right;

    // 怪物移动方向
    public bool isRight = false;

    // 怪物移动的速度
    public float speed = 1f;

    // 怪物是否可以移动
    public bool canMove = true;

    // 添加刚体
    public Rigidbody2D rb;

    [Header("Enemy Pursuit")]
    // 击状态
    public GameObject player;


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

    /// <summary>
    /// 切换状态
    /// </summary>
    public virtual void ChangeIdleToPatrolState()
    {
        isRight = !isRight;
        // 向右移动
        spriteRenderer.flipX = isRight;
        ChangeCurrentState(EnemyState.Patrol);
    }

    /// <summary>
    /// 查找玩家
    /// </summary>
    public virtual void FindPlayer(GameObject mainPlayer)
    {
        player = mainPlayer;
        // 更新玩家状态
        ChangeCurrentState(EnemyState.Pursuit);
    }

    /// <summary>
    /// 玩家退出状态
    /// </summary>
    public virtual void PlayerOut()
    {
        // 切换玩家状态为巡逻状态
        ChangeCurrentState(EnemyState.Patrol);
    }

    public virtual void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocityX = (isRight ? 1 : -1) * speed;
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }

    #region 状态机

    public virtual void IdleEnter()
    {
        canMove = false;
        // 播放待机动画
        enemyAnimator.SetBool("IsRun", false);
        Invoke(nameof(ChangeIdleToPatrolState), idleTime);
    }

    public virtual void IdleUpdate()
    {
    }

    public virtual void IdleExit()
    {
    }


    /// <summary>
    /// 巡逻
    /// </summary>
    public virtual void PatrolEnter()
    {
        canMove = true;
        enemyAnimator.SetBool("IsRun", true);
    }

    public virtual void PatrolUpdate()
    {
        if (transform.position.x <= left.position.x && !isRight)
        {
            // 切换到暂停状态
            ChangeCurrentState(EnemyState.Idle);
        }
        else if (transform.position.x >= right.position.x && isRight)
        {
            ChangeCurrentState(EnemyState.Idle);
        }
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
    public virtual void ChangeCurrentState(EnemyState state)
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                IdleExit();
                break;
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
            case EnemyState.Idle:
                IdleEnter();
                break;
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