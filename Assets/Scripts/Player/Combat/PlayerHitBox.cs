using UnityEngine;
using System.Collections;

public class PlayerHitBox : MonoBehaviour
{

    private PlayerBehaviour playerB;
    private EnemyBehaviour enemyB;
    private Health health;

    void Start()
    {
        playerB = GameManager.instance.playerB;
        health = GameManager.instance.health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RegularEnemyBehaviour>() && other is CapsuleCollider)
        {
            if (playerB.shieldIsUp)
            {
                other.GetComponent<RegularEnemyBehaviour>().EnemyBounceBack(transform.parent, 7f);
            }
            else if (!playerB.shieldIsUp)
            {
                health.TakeDamage(1);
                playerB.PlayerBounceBack(other.transform, 7f);
            }
        }
    }
}
