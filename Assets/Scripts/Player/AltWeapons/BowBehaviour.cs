using UnityEngine;
using System.Collections;

public class BowBehaviour : MonoBehaviour {

    private AltWeapons altWeapons;

    void Start () {
        altWeapons = FindObjectOfType<AltWeapons>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BowObject"))
        {
            other.GetComponent<SwitchEvent>().activateSwitch = true;
            altWeapons.bow.currentState = BowState.Idle;

            Destroy(this.gameObject);

            altWeapons.canUseAltWeapon = true;
            altWeapons.swordAndShieldShowing = true;
            altWeapons.tpc.canMove = true;
        }
        else if (!other.GetComponent<ThirdPersonController>() && !other.GetComponent<PlayerHitBox>() && !(other.CompareTag("Enemy") && (other.GetType() == typeof(SphereCollider))) && other.gameObject.layer != 8)
        {
            Destroy(this.gameObject);

            altWeapons.bow.currentState = BowState.Idle;

            altWeapons.canUseAltWeapon = true;
            altWeapons.swordAndShieldShowing = true;
            altWeapons.tpc.canMove = true;
        }

        if (other.CompareTag("Enemy") && (other.GetType() == typeof(CapsuleCollider)))
        {
            other.GetComponent<EnemyBehaviour>().EnemyBounceBack(transform, 7f);
            other.GetComponent<EnemyBehaviour>().health -= 1;

            Destroy(this.gameObject);

            altWeapons.canUseAltWeapon = true;
            altWeapons.swordAndShieldShowing = true;
            altWeapons.tpc.canMove = true;
        } else if (other.CompareTag("BossEnemy")) {
            other.GetComponent<BossEnemyBehaviour>().health -= 1;

            Destroy(this.gameObject);

            altWeapons.canUseAltWeapon = true;
            altWeapons.swordAndShieldShowing = true;
            altWeapons.tpc.canMove = true;
        }
    }
}
