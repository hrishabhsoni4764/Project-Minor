using UnityEngine;
using System.Collections;

public enum BoomerangState { Idle, Shoot, Retract };
public class BoomerangController : MonoBehaviour {

    [HideInInspector] public bool active;
    [HideInInspector] public BoomerangState currentState;
    [HideInInspector] public AltWeapons altweapons;

    public float shootingLength = 7f;
    private float shootingSpeed = 0.3f;
    private float retractingSpeed = 0.3f;
    private Rigidbody rb;

    private Transform boomerangObj;
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	

	void Update () {
        if (active) {
            switch (currentState)
            {
                case BoomerangState.Idle:
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    if (Input.GetButtonDown("AltWeapon") && altweapons.canUseAltWeapon) {
                        GameObject altWeaponInUse = Instantiate(altweapons.altWeapons[0], altweapons.altWeaponPos, Quaternion.identity) as GameObject;
                        boomerangObj = altWeaponInUse.transform;
                        altweapons.canUseAltWeapon = false;
                        altweapons.swordAndShieldShowing = false;
                        altweapons.tpc.canMove = false;
                        altweapons.tpc.canLookAround = false;
                        currentState = BoomerangState.Shoot;
                    }
                    break;
                case BoomerangState.Shoot:
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    ShootBoomerang();
                    break;
                case BoomerangState.Retract:
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    RetractBoomerang();
                    break;
                default:
                    break;
            }
        }
	}

    void ShootBoomerang() {
        boomerangObj.position += transform.forward * shootingSpeed;
        float distance = Vector3.Distance(altweapons.altWeaponPos, boomerangObj.position);
        if (distance > shootingLength) {
            currentState = BoomerangState.Retract;
        }
    }

    void RetractBoomerang() {

        boomerangObj.position -= transform.forward * retractingSpeed;

        Vector3 retractPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + shootingLength);
        float distance = Vector3.Distance(altweapons.altWeaponPos, boomerangObj.position);
        float resetDistance = Vector3.Distance(retractPoint, boomerangObj.position);

        if (distance <= 1)
        {
            altweapons.canUseAltWeapon = true;
            altweapons.swordAndShieldShowing = true;
            altweapons.tpc.canMove = true;
            altweapons.tpc.canLookAround = true;
            Destroy(boomerangObj.gameObject);
            currentState = BoomerangState.Idle;
        }
        else if (resetDistance >= 15f)
        {
            altweapons.canUseAltWeapon = true;
            altweapons.swordAndShieldShowing = true;
            altweapons.tpc.canMove = true;
            altweapons.tpc.canLookAround = true;
            currentState = BoomerangState.Idle;
            Destroy(boomerangObj.gameObject);
        }
    }
}
