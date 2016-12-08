using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum InteractibleType { Chest, NPC, Door }
public class Interactible : MonoBehaviour {

    private ChestLoot chestLoot;
    private VillagerBehaviour villagerB;
    private AltWeaponOnScreen altOS;
    private EnterTransitionTrigger ett;
    private Coroutine currentRoutine;
    [HideInInspector] public GameObject buttonCanvas;

    public InteractibleType interactibleType;

    void Start() {
        buttonCanvas = transform.FindChild("Canvas").gameObject;
        chestLoot = GetComponent<ChestLoot>();
        ett = GetComponent<EnterTransitionTrigger>();
        villagerB = GetComponent<VillagerBehaviour>();
        altOS = FindObjectOfType<AltWeaponOnScreen>();
    }

    void Update() {
        if (buttonCanvas != null)
        {
            buttonCanvas.transform.FindChild("Image").forward = Camera.main.transform.forward * -1;
            buttonCanvas.transform.FindChild("Speechbubble").forward = Camera.main.transform.forward * -1;
        }
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

    public void TextFading(float fadeSpeed)
    {
        Color textColor = buttonCanvas.transform.GetChild(1).GetChild(0).GetComponent<Text>().color;
        if (textColor.a == 1)
        {
            currentRoutine = StartCoroutine(TextFadingOut(textColor, fadeSpeed));
        }
        else if (textColor.a == 0)
        {
            currentRoutine = StartCoroutine(TextFadingIn(textColor, fadeSpeed));
        }
    }   

    public IEnumerator TextFadingIn(Color textColor, float fadeSpeed) {
        Color vis = textColor;
        vis.a = 1f;
        while (textColor.a < 1f)
        {
            print("Text fading in");
            textColor.a = Color.Lerp(textColor, vis, 0.01f).a;
            yield return new WaitForSeconds(fadeSpeed);
        }
    }

    public IEnumerator TextFadingOut(Color textColor, float fadeSpeed)
    {
        Color invis = textColor;
        invis.a = 1f;
        while (textColor.a < 1f)
        {
            print("Text fading out");
            textColor.a = Color.Lerp(textColor, invis, 0.01f).a;
            yield return new WaitForSeconds(fadeSpeed);
        }
    }

    public IEnumerator TextDelay() {
        yield return new WaitForSeconds(.3f);
        buttonCanvas.transform.GetChild(1).GetComponentInChildren<Text>().text = (villagerB.dialogueTextInput);
    }
}
