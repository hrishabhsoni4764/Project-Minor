using UnityEngine;
using System.Collections;

public class FlyingEnemyBehaviour : EnemyBehaviour
{

    //[HideInInspector] public Vector3 defaultpos = new Vector3(22.9f, 1.01f, -19.84f);

    void Start()
    {
        health = 2;
        atkDamage = 1;
        moveSpeed = 0.5f;
        player = FindObjectOfType<ThirdPersonController>().gameObject;
    }

    void Update()
    {
        base.Update();
        EnemyDeath();
        if (enemyIsAgrrod)
        {
            Vector3 targetPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
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
        if (transform.position.y != 3.5f) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 3.5f, transform.position.z), 3f * Time.deltaTime);
        }
    }

    protected override void Chasing()
    {
        enemyIsAgrrod = true;
        isLooking = true;

        Vector3 playerXZ = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        Vector3 enemyXZ = new Vector3(transform.position.x, 0f, transform.position.z);

        float stopDistance = 2.5f;
        float currentDistance = Vector3.Distance(enemyXZ, playerXZ);

        if (currentDistance <= stopDistance) {
            currentState = EnemyState.Attack;
        }
    }

    protected override void Attack()
    {
        enemyIsAgrrod = false;
        isLooking = false;

        StartCoroutine("Charge");

        float stopDistance = .5f;
        Vector3 playerXZ = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        Vector3 enemyXZ = new Vector3(transform.position.x, 0f, transform.position.z);
        float currentDistance = Vector3.Distance(enemyXZ, playerXZ);
        if (currentDistance <= stopDistance)
        {
            currentState = EnemyState.Chasing;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            currentState = EnemyState.Chasing;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    IEnumerator Charge() {
        yield return new WaitForSeconds(.5f);
        transform.position += transform.forward * 0.6f;
    }
}
