using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PushBlock : MonoBehaviour {

    private GameObject buttonInterface;
    private AltWeapons altweapons;
    private ThirdPersonController tpc;

	void Start () {
        buttonInterface = FindObjectOfType<AltWeaponOnScreen>().gameObject;
        altweapons = FindObjectOfType<AltWeapons>();
        tpc = FindObjectOfType<ThirdPersonController>();
	}

    void Update() {
        if (Input.GetButtonUp("Interact")) {
            transform.SetParent(null);
            altweapons.swordAndShieldShowing = true;
            altweapons.canUseAltWeapon = true;
            tpc.canLookAround = true;
            tpc.defaultSpeed = 7f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>()) {
            buttonInterface.transform.FindChild("Push").gameObject.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                transform.SetParent(other.transform);
                altweapons.swordAndShieldShowing = false;
                altweapons.canUseAltWeapon = false;
                other.GetComponent<ThirdPersonController>().canLookAround = false;
                other.GetComponent<ThirdPersonController>().defaultSpeed = 2f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
        {
            buttonInterface.transform.FindChild("Push").gameObject.SetActive(false);
        }
    }
}
