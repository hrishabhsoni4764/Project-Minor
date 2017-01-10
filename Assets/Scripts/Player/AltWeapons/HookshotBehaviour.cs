using UnityEngine;
using System.Collections;

public class HookshotBehaviour : MonoBehaviour
{
    private AltWeapons altWeapons;

    void Start()
    {
        altWeapons = GameManager.instance.altWeapons;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HookshotObject"))
        {
            altWeapons.hookshot.currentState = HookshotState.HookedOnTarget;
        }
        else if (!other.GetComponent<ThirdPersonController>() && !other.GetComponent<PlayerHitBox>() && !(other.CompareTag("Enemy") && (other.GetType() == typeof(SphereCollider))) && other.gameObject.layer != 8) {
            altWeapons.hookshot.currentState = HookshotState.Retract;
        }

        if (other.CompareTag("Enemy") && (other.GetType() == typeof(CapsuleCollider)))
        {
            other.GetComponent<EnemyBehaviour>().EnemyBounceBack(transform, 7f);
        }
    }
}
