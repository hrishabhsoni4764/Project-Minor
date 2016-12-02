using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum LootTypes { Key, Bosskey, AltWeapon}
public class ChestLoot : MonoBehaviour {

    public LootTypes lootType;
    public string lootText;
    private bool chestLooted;
    private UIKey uiKey;

    void Start() {
        uiKey = FindObjectOfType<UIKey>();
    }

    void OnTriggerStay(Collider other)
    {
        if (!chestLooted)
        {
            if (other.GetComponent<ThirdPersonController>())
            {
                GameObject buttonPrompt = GameManager.instance.buttonPrompt;
                buttonPrompt.SetActive(true);
                buttonPrompt.GetComponentInChildren<Text>().text = ("Press O to Open");
                if (Input.GetKeyDown(KeyCode.O))
                {
                    switch (lootType)
                    {
                        case LootTypes.Key:
                            buttonPrompt = GameManager.instance.buttonPrompt;
                            buttonPrompt.SetActive(false);
                            StartCoroutine("DialogueTimer", lootText);
                            UIKey.keyAmount++;
                            chestLooted = true;
                            break;
                        case LootTypes.Bosskey:
                            buttonPrompt = GameManager.instance.buttonPrompt;
                            buttonPrompt.SetActive(false);
                            StartCoroutine("DialogueTimer", lootText);
                            uiKey.gotBossKey = true;
                            chestLooted = true;
                            break;
                        case LootTypes.AltWeapon:
                            buttonPrompt = GameManager.instance.buttonPrompt;
                            buttonPrompt.SetActive(false);
                            StartCoroutine("DialogueTimer", lootText);
                            FindObjectOfType<AltWeaponOnScreen>().altweaponsOnScreen = AltWeaponsOnScreen.Two;
                            chestLooted = true;
                            break;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            GameObject buttonPrompt = GameManager.instance.buttonPrompt;
            buttonPrompt.SetActive(false);
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
}
