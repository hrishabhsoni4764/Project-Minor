using UnityEngine;
using System.Collections;

public class Interactible : MonoBehaviour {

    private ChestLoot chestLoot;

    void Start() {
        chestLoot = GetComponent<ChestLoot>();
    }

    void Update() {
        transform.GetChild(0).GetChild(0).forward = Camera.main.transform.forward * -1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!chestLoot.chestLooted)
        {
            if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
            {
                transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
            }
        }
        else {
            transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!chestLoot.chestLooted)
        {
            if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
            {
                transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
            }
        }
        else {
            transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
        }
    }
}
