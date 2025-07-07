using UnityEngine;

public class Player : MonoBehaviour
{
    // 玩家物体
    public GameObject player;
    // 玩家移动的方向
    public Vector2 playerDir;
    // 玩家刚体
    public Rigidbody2D rb;
    
    void Update()
    {
        PlayerMove();
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(playerDir);
        }
    }
}