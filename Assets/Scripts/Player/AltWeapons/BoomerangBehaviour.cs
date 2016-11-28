using UnityEngine;
using System.Collections;

public class BoomerangBehaviour : MonoBehaviour {

    private AltWeapons altWeapons;
    private EnemyBehaviour enemyB;

    void Start() {
        altWeapons = FindObjectOfType<AltWeapons>();
        enemyB = FindObjectOfType<EnemyBehaviour>();
    }

    void Update() {
        boomerangSpin();
    }

    void boomerangSpin() {
        transform.Rotate(Vector3.up * 25f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BoomerangObject") && !other.GetComponent<ThirdPersonController>() && !other.GetComponent<PlayerHitBox>())
        {
            other.GetComponent<SwitchEvent>().switchEventActivate = true;
        }
        if (!other.GetComponent<ThirdPersonController>() && !other.GetComponent<PlayerHitBox>() && !(other.CompareTag("Enemy") && (other.GetType() == typeof(SphereCollider))) && other.gameObject.layer != 8)
        {
            altWeapons.boomerang.currentState = BoomerangState.Retract;
        }

        if (other.CompareTag("Enemy") && (other.GetType() == typeof(CapsuleCollider)))
        {
            enemyB.EnemyBounceBack(transform, 6f);
            StartCoroutine("EnemyStun");
        }
    }

    IEnumerator EnemyStun()
    {
        enemyB.enemyIsStunned = true;
        yield return new WaitForSeconds(4);
        enemyB.enemyIsStunned = false;
    }

}
