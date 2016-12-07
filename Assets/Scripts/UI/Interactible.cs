using UnityEngine;
using System.Collections;

public enum InteractibleType { Chest, NPC, Door }
public class Interactible : MonoBehaviour {

    private ChestLoot chestLoot;
    private VillagerBehaviour villgerB;
    private AltWeaponOnScreen altOS;

    public InteractibleType interactibleType;

    void Start() {
        chestLoot = GetComponent<ChestLoot>();
        villgerB = GetComponent<VillagerBehaviour>();
        altOS = FindObjectOfType<AltWeaponOnScreen>();
    }

    void Update() {
        transform.GetChild(0).GetChild(0).forward = Camera.main.transform.forward * -1;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (interactibleType)
        {
            case InteractibleType.Chest:
                if (!chestLoot.chestLooted)
                {
                    if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
                    {
                        transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
                        altOS.transform.GetChild(1).gameObject.SetActive(true);
                    }
                }
                else {
                    transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                    altOS.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
            case InteractibleType.NPC:
                transform.GetChild(2).GetComponent<Animator>().SetInteger("interactButton", 1);
                break;
            case InteractibleType.Door:
                break;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        switch (interactibleType)
        {
            case InteractibleType.Chest:
                if (!chestLoot.chestLooted)
                {
                    if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
                    {
                        transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                        altOS.transform.GetChild(1).gameObject.SetActive(false);
                    }
                }
                else {
                    transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                    altOS.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
            case InteractibleType.NPC:
                break;
            case InteractibleType.Door:
                break;
        }
        
    }
}
