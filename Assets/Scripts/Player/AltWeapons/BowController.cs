using UnityEngine;
using System.Collections;

public enum BowState { Idle, Shoot };
public class BowController : MonoBehaviour {

    [HideInInspector] public bool active;
    [HideInInspector] public BowState currentState;
    [HideInInspector] public AltWeapons altweapons;
    [HideInInspector] public float shootingSpeed = 0.5f;

    private float shootingLength = 15f;

    private Transform bowObj;

	void Start () {
	
	}
	
	void Update () {
        if (active)
        {
            switch (currentState)
            {
                case BowState.Idle:
                    if (Input.GetKeyDown(KeyCode.Space) && altweapons.canUseAltWeapon)
                    {
                        GameObject altWeaponInUse = Instantiate(altweapons.altWeapons[2], altweapons.altWeaponPos, Quaternion.LookRotation(transform.forward)) as GameObject;
                        bowObj = altWeaponInUse.transform;
                        altweapons.canUseAltWeapon = false;
                        altweapons.swordAndShieldShowing = false;
                        altweapons.tpc.canMove = false;
                        altweapons.tpc.canLookAround = false;
                        currentState = BowState.Shoot;
                    }
                    break;
                case BowState.Shoot:
                    ShootArrow();
                    break;
                default:
                    break;
            }
        }
    }

    void ShootArrow() {
        bowObj.position += transform.forward * shootingSpeed;
        float distance = Vector3.Distance(altweapons.altWeaponPos, bowObj.position);
        if (distance > shootingLength)
        {
            altweapons.canUseAltWeapon = true;
            altweapons.swordAndShieldShowing = true;
            altweapons.tpc.canMove = true;
            altweapons.tpc.canLookAround = true;
            Destroy(bowObj.gameObject);
            currentState = BowState.Idle;
        }
    }
}
