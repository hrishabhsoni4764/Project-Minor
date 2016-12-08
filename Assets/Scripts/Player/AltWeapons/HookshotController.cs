using UnityEngine;
using System.Collections;

public enum HookshotState { Idle, Shoot, Retract, HookedOnTarget };
public class HookshotController : MonoBehaviour {
    [HideInInspector] public bool active;
    [HideInInspector] public HookshotState currentState;
    [HideInInspector] public AltWeapons altweapons;
    [HideInInspector] public float shootingSpeed = 0.4f;

    public float shootingLength = 6f;
    private float retractingSpeed = 0.4f;
    private Rigidbody rb;

    private Transform hookshotObj;
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {

        if (active)
        {
            switch (currentState)
            {
                case HookshotState.Idle:
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    if (Input.GetButtonDown("AltWeapon") && altweapons.canUseAltWeapon)
                    {
                        GameObject altWeaponInUse = Instantiate(altweapons.altWeapons[1], altweapons.altWeaponPos, Quaternion.identity) as GameObject;
                        hookshotObj = altWeaponInUse.transform;
                        altweapons.canUseAltWeapon = false;
                        altweapons.swordAndShieldShowing = false;
                        altweapons.tpc.canMove = false;
                        altweapons.tpc.canLookAround = false;
                        currentState = HookshotState.Shoot;
                    }
                    break;
                case HookshotState.Shoot:
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    ShootHookshot();
                    break;
                case HookshotState.Retract:
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    RetractHookshot();
                    break;
                case HookshotState.HookedOnTarget:
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    HookedOnTarget();
                    break;
                default:
                    break;
            }
        }
	}

    void ShootHookshot ()
    {
        hookshotObj.position += transform.forward * shootingSpeed;
        float distance = Vector3.Distance(altweapons.altWeaponPos, hookshotObj.position);
        if (distance > shootingLength) {
            currentState = HookshotState.Retract;
        }
    }

    void RetractHookshot() {

        hookshotObj.position -= transform.forward * retractingSpeed;

        Vector3 retractPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + shootingLength);
        float distance = Vector3.Distance(altweapons.altWeaponPos, hookshotObj.position);
        float resetDistance = Vector3.Distance(retractPoint, hookshotObj.position);

        if (distance <= 1)
        {
            altweapons.canUseAltWeapon = true;
            altweapons.swordAndShieldShowing = true;
            altweapons.tpc.canMove = true;
            altweapons.tpc.canLookAround = true;
            currentState = HookshotState.Idle;
            Destroy(hookshotObj.gameObject);
        }
        else if (resetDistance >= 15f)
        {
            altweapons.canUseAltWeapon = true;
            altweapons.swordAndShieldShowing = true;
            altweapons.tpc.canMove = true;
            altweapons.tpc.canLookAround = true;
            currentState = HookshotState.Idle;
            Destroy(hookshotObj.gameObject);
        }
    }

    void HookedOnTarget() {
        altweapons.tpc.TowardsHookshotTarget(hookshotObj);
    }
}
