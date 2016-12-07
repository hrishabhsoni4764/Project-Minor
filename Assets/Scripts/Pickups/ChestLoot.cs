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

    void Start() {
        uiKey = FindObjectOfType<UIKey>();
        cameraM = FindObjectOfType<CameraMovement>();
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
                            StartCoroutine("DialogueTimer", lootText);
                            if (cameraPan)
                            {
                                StartCoroutine("CameraPan");
                            }
                            UIKey.keyAmount++;
                            chestLooted = true;
                            break;
                        case LootTypes.Bosskey:
                            StartCoroutine("DialogueTimer", lootText);
                            if (cameraPan)
                            {
                                StartCoroutine("CameraPan");
                            }
                            uiKey.gotBossKey = true;
                            chestLooted = true;
                            break;
                        case LootTypes.AltWeapon:
                            StartCoroutine("DialogueTimer", lootText);
                            if (cameraPan)
                            {
                                StartCoroutine("CameraPan");
                            }
                            FindObjectOfType<AltWeaponOnScreen>().altweaponsOnScreen = AltWeaponsOnScreen.Two;
                            chestLooted = true;
                            break;
                    }
                }
            }
        }
    }

    IEnumerator DialogueTimer(string text)
    {
        GameObject dialoguePrompt = GameManager.instance.dialoguePrompt;
        dialoguePrompt.SetActive(true);
        dialoguePrompt.GetComponentInChildren<Text>().text = (text);
        yield return new WaitForSeconds(2);
        dialoguePrompt.SetActive(false);
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
}
