using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum LootTypes { Key, Bosskey, AltWeapon}
public class ChestLoot : MonoBehaviour {

    [Header("-Event Panning-")]
    public bool cameraPan;
    public GameObject objectToTrigger;
    public Transform targetMove;

    public Transform panTarget;
    public int height;
    public int panPause;
    public int animPause;

    [Header("-Chest Options-")]
    public LootTypes lootType;
    public string lootText;

    [HideInInspector] public bool chestLooted;
    private UIKey uiKey;
    private CameraMovement cameraM;
    private AltWeaponOnScreen altOS;

    [HideInInspector] public GameObject dialoguePrompt;

    void Start() {
        uiKey = GameManager.instance.uiKey;
        cameraM = GameManager.instance.cameraM;
        altOS = GameManager.instance.altOS;
        dialoguePrompt = transform.GetChild(0).GetChild(1).gameObject;
    }

    void OnTriggerStay(Collider other)
    {
        if (!chestLooted)
        {
            if (other.GetComponent<ThirdPersonController>())
            {
                if (Input.GetButtonDown("Interact"))
                {
                    switch (lootType)
                    {
                        case LootTypes.Key:
                            dialoguePrompt.SetActive(true);
                            dialoguePrompt.GetComponent<Animator>().SetInteger("speechBubble", 1);
                            StartCoroutine("TextDelay", lootText);
                            if (cameraPan)
                            {
                                StartCoroutine("CameraPan");
                            }
                            UIKey.keyAmount++;
                            chestLooted = true;
                            break;
                        case LootTypes.Bosskey:
                            dialoguePrompt.SetActive(true);
                            dialoguePrompt.GetComponent<Animator>().SetInteger("speechBubble", 1);
                            StartCoroutine("TextDelay", lootText);
                            if (cameraPan)
                            {
                                StartCoroutine("CameraPan");
                            }
                            uiKey.gotBossKey = true;
                            chestLooted = true;
                            break;
                        case LootTypes.AltWeapon:
                            dialoguePrompt.SetActive(true);
                            dialoguePrompt.GetComponent<Animator>().SetInteger("speechBubble", 1);
                            StartCoroutine("TextDelay", lootText);
                            if (cameraPan)
                            {
                                StartCoroutine("CameraPan");
                            }
                            if (altOS.altweaponsOnScreen == AltWeaponsOnScreen.Zero) {
                                altOS.altweaponsOnScreen = AltWeaponsOnScreen.One;
                            } else if (altOS.altweaponsOnScreen == AltWeaponsOnScreen.One) {
                                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Two;
                            } else if (altOS.altweaponsOnScreen == AltWeaponsOnScreen.Two) {
                                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Three;
                            }
                            chestLooted = true;
                            break;
                    }
                }
            }
        }
    }

    IEnumerator CameraPan() {
        cameraM.panTarget = panTarget;
        cameraM.panHeight = height;
        cameraM.panPause = panPause;
        cameraM.cameraState = CameraState.Pan;
        yield return new WaitForSeconds(animPause);
        objectToTrigger.GetComponent<DoorEvent>().active = true;
        objectToTrigger.GetComponent<DoorEvent>().posToMoveTo = targetMove;
    }

    IEnumerator TextDelay(string lootText) {
        yield return new WaitForSeconds(0.3f);
        dialoguePrompt.GetComponentInChildren<Text>().text = lootText;
    }
}
