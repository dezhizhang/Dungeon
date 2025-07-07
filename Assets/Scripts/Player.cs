using UnityEngine;

public class Player : MonoBehaviour
{
    // 玩家物体
    public GameObject player;

    public Vector2 playerDir;

    // Update is called once per frame
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
            player.transform.Translate(playerDir * Time.deltaTime);
        }
    }
}