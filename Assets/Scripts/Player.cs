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

    [Header("PlayerJump")] public float jumpForce = 400;

    // 玩家对像
    public GameObject playerGo;
    public LayerMask groundLayer;
    public bool isGround = true;


    private void Update()
    {
        PlayerMove();
        PlayerJump();
        // 检测地面
        CheckGround();
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

        // 判断玩家是否在移动
        if (_xInput != 0 && !playerAnimator.GetBool("IsRun"))
        {
            playerAnimator.SetBool("IsRun", true);

            // 判断玩家是否向右移动
            if (_xInput > 0 && isRight == false)
            {
                isRight = true;
                playerSprite.flipX = false;
            }
            else if (_xInput < 0 && isRight)
            {
                // 角色默认朝右
                isRight = false;
                playerSprite.flipX = true;
            }
        }
        else if (playerAnimator.GetBool("IsRun"))
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

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            // 刚体向上跳跃
            rb.AddForce(new Vector2(rb.linearVelocityX, jumpForce));
            playerAnimator.SetTrigger("IsJump");
        }
    }

    private void CheckGround()
    {
        Vector3 startPos = playerGo.transform.position;
        Vector2 endPos = playerGo.transform.position + Vector3.down * 0.5f;
        RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, groundLayer);

        if (hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}