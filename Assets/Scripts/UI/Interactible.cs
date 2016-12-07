using UnityEngine;
using System.Collections;

public enum InteractibleType { Chest, NPC, Door }
public class Interactible : MonoBehaviour {

    private ChestLoot chestLoot;
    private VillagerBehaviour villgerB;
    private AltWeaponOnScreen altOS;
    private EnterTransitionTrigger ett;
    [HideInInspector] public GameObject buttonCanvas;

    public InteractibleType interactibleType;

    void Start() {
        buttonCanvas = transform.FindChild("Canvas").gameObject;
        chestLoot = GetComponent<ChestLoot>();
        ett = GetComponent<EnterTransitionTrigger>();
        villgerB = GetComponent<VillagerBehaviour>();
        altOS = FindObjectOfType<AltWeaponOnScreen>();
    }

    void Update() {
        buttonCanvas.transform.GetChild(0).forward = Camera.main.transform.forward * -1;
        buttonCanvas.transform.GetChild(1).forward = Camera.main.transform.forward * -1;
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
                        buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
                        altOS.transform.GetChild(1).gameObject.SetActive(true);
                    }
                }
                else {
                    buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                    altOS.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
            case InteractibleType.NPC:
                if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
                {
                    buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
                    altOS.transform.GetChild(0).gameObject.SetActive(true);
                }
                break;
            case InteractibleType.Door:
                if (ett.enablePrompt)
                {
                    buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
                    altOS.transform.GetChild(1).gameObject.SetActive(true);
                }
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
                        buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                        altOS.transform.GetChild(1).gameObject.SetActive(false);
                    }
                }
                else {
                    buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                    altOS.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
            case InteractibleType.NPC:
                if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
                {
                    buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                    altOS.transform.GetChild(0).gameObject.SetActive(false);
                }
                break;
            case InteractibleType.Door:
                if (ett.enablePrompt)
                {
                    buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                    altOS.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
        }
        
    }
}
