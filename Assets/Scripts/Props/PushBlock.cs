using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PushBlock : MonoBehaviour {

    private GameObject buttonInterface;
    private AltWeapons altweapons;
    private ThirdPersonController tpc;
    private Rigidbody rb;

	void Start () {
        buttonInterface = GameManager.instance.altOS.gameObject;
        altweapons = GameManager.instance.altWeapons;
        tpc = GameManager.instance.tpc;
        rb = GetComponent<Rigidbody>();
	}

    void Update() {
        if (Input.GetButtonUp("Interact")) {
            if (transform.parent.gameObject.layer != 10) {
                transform.parent.SetParent(null);
            }
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
                transform.parent.SetParent(other.transform);
                altweapons.swordAndShieldShowing = false;
                altweapons.canUseAltWeapon = false;
                other.GetComponent<ThirdPersonController>().canLookAround = false;
                other.GetComponent<ThirdPersonController>().defaultSpeed = 4f;
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
