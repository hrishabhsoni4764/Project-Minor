using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyState { Idle, Chasing, Attack };
public class EnemyBehaviour : MonoBehaviour {

    [HideInInspector] public GameObject player;
    [HideInInspector] public bool isLooking = false;
    [HideInInspector] public bool enemyIsAgrrod = false;
    [HideInInspector] public bool enemyCanMove = true;
    [HideInInspector] public bool enemyIsStunned = false;
    [HideInInspector] public bool active;
    [HideInInspector] public Vector3 defaultpos;
    /*[HideInInspector]*/ public EnemyState currentState;

    public int health;
    public int atkDamage;
    public float moveSpeed;

    private float aggroDissipate = 2.5f;

    void Start () {
        player = FindObjectOfType<ThirdPersonController>().gameObject;
	}
	
	protected void Update () {
        if (!enemyIsStunned)
        {
            if (enemyCanMove)
            {
                switch (currentState)
                {
                    case EnemyState.Idle:
                        Idle();
                        break;
                    case EnemyState.Chasing:
                        Chasing();
                        break;
                    case EnemyState.Attack:
                        Attack();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    protected virtual void Idle() {

    }
    protected virtual void Chasing()
    {

    }
    protected virtual void Attack()
    {

    }

    public void EnemyBounceBack(Transform playerTrans, float pushBackPower)
    {
        Vector3 pushbackDirection = transform.position - playerTrans.position;
        pushbackDirection.Normalize();
        GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackPower, ForceMode.VelocityChange);
    }

    protected virtual void OnTriggerStay(Collider other) {
        
    }

    protected void OnTriggerExit(Collider other) {
        if (other.gameObject == player)
        {
            StartCoroutine("EnemyCalmDown");
        }
    }

    protected virtual void EnemyDeath()
    {
        if (health <= 0)
        {
            StartCoroutine("DeathDelay");
        }
    }

    IEnumerator EnemyCalmDown()
    {
        yield return new WaitForSeconds(aggroDissipate);
        currentState = EnemyState.Idle;
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
