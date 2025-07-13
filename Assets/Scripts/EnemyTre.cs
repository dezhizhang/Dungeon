using System;
using UnityEngine;

public class EnemyTre : MonoBehaviour
{
    public EnemyBase enemyBase;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyBase.FindPlayer(collision.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyBase.PlayerOut();
        }
    }

}

