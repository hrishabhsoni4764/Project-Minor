using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum LootTypes { Key, Bosskey, AltWeapon}
public class ChestLoot : MonoBehaviour {

    public LootTypes lootType;
    public string lootText;
    [HideInInspector] public bool chestLooted;
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
                if (Input.GetKeyDown(KeyCode.O))
                {
                    switch (lootType)
                    {
                        case LootTypes.Key:
                            StartCoroutine("DialogueTimer", lootText);
                            UIKey.keyAmount++;
                            chestLooted = true;
                            break;
                        case LootTypes.Bosskey:
                            StartCoroutine("DialogueTimer", lootText);
                            uiKey.gotBossKey = true;
                            chestLooted = true;
                            break;
                        case LootTypes.AltWeapon:
                            StartCoroutine("DialogueTimer", lootText);
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
}
