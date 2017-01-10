using UnityEngine;
using System.Collections;

public class PlayerHitBox : MonoBehaviour {

    private PlayerBehaviour playerB;
    private EnemyBehaviour enemyB;

	void Start () {
        playerB = GameManager.instance.playerB;
        enemyB = GetComponent<EnemyBehaviour>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (enemyB == null) return;
       
        if (other == enemyB.GetComponent<CapsuleCollider>() && playerB.shieldIsUp)
        {
            enemyB.EnemyBounceBack(transform.parent, 10f);
        }
        
    }
}
