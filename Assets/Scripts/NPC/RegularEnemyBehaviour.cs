using UnityEngine;
using System.Collections;

public class RegularEnemyBehaviour : EnemyBehaviour {

    //[HideInInspector] public Vector3 defaultpos = new Vector3(-11.58f, 1.01f, 10.47f);

    void Start()
    {
        health = 3;
        atkDamage = 1;
        moveSpeed = 0.5f;
        player = GameManager.instance.tpc.gameObject;
    }

    void Update () {
        base.Update();
        EnemyDeath();
        if (enemyIsAgrrod) {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        if (isLooking)
        {
            transform.LookAt(player.transform.position);
        }
    }

    protected override void Idle()
    {
        enemyIsAgrrod = false;
        isLooking = false;
    }

    protected override void Attack()
    {
        enemyIsAgrrod = true;
        isLooking = true;
    }

    protected override void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.Attack;
        }
    }

}
