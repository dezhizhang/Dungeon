using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerMove")]
    // 玩家刚体
    public Rigidbody2D rb;

    // 玩家按臽输入
    private float _xInput;

    private float _speed = 5;

    // 玩家动画
    public Animator playerAnimator;

    // 定义玩家朝向
    public bool isRight = true;
    // 玩家转向
    public SpriteRenderer playerSprite;


    private void Update()
    {
        PlayerMove();
    }


    private void FixedUpdate()
    {
        FixPlayerMove();
    }

    /// <summary>
    /// 玩家键盘输入
    /// </summary>
    private void PlayerMove()
    {
        // 获取鼠标输入
        _xInput = Input.GetAxisRaw("Horizontal");
        // 设置玩家动画
        if (_xInput != 0 && isRight)
        {
            playerAnimator.SetBool("IsRun", true);
        }
        else if (_xInput != 0)
        {
        }
        else
        {
            playerAnimator.SetBool("IsRun", false);
        }
    }


    /// <summary>
    /// 玩家移动
    /// </summary>
    private void FixPlayerMove()
    {
        rb.linearVelocity = new Vector2(_xInput * _speed, rb.linearVelocityY);
    }
}