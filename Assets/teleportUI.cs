using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportUI : MonoBehaviour {

    private AltWeaponOnScreen altOS;

	void Start () {
        altOS = GameManager.instance.altOS;
	}
	
	void Update () {
        transform.GetChild(0).forward = Camera.main.transform.forward * -1;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
        {
            transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
            altOS.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
        {
            transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
            altOS.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
