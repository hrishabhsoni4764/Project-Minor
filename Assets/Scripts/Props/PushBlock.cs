using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PushBlock : MonoBehaviour {

    private GameObject buttonInterface;
    private AltWeapons altweapons;
    private PlayerBehaviour playerB;
    private ThirdPersonController tpc;

    public GameObject originParent;

	void Start () {
        buttonInterface = GameManager.instance.altOS.gameObject;
        altweapons = GameManager.instance.altWeapons;
        playerB = GameManager.instance.playerB;
        tpc = GameManager.instance.tpc;
	}

    void Update() {
        if (Input.GetButtonUp("Interact")) {
            if (transform.parent.gameObject.layer != 10) {
                transform.parent.SetParent(originParent.transform);
            }
            altweapons.swordAndShieldShowing = true;
            playerB.canUseShieldAndSword = true;
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
                playerB.canUseShieldAndSword = false;
                altweapons.canUseAltWeapon = false;
                tpc.canLookAround = false;
                tpc.defaultSpeed = 4f;
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
