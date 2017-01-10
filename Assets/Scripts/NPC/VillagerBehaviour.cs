using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillagerBehaviour : MonoBehaviour {

    public string dialogueTextInput;

    private GameObject dialoguePrompt;
    private ThirdPersonController player;
    private Interactible interactible;
    private CameraMovement cameraM;

    [HideInInspector] public bool isLooking = false, isTalking = false, isInRange = false;

    void Start () {
        dialoguePrompt = GameManager.instance.dialoguePrompt;
        player = GameManager.instance.tpc;
        interactible = GetComponent<Interactible>();
        cameraM = GameManager.instance.cameraM;

    }

    void LateUpdate() {
        if (isLooking) {
            transform.LookAt(player.transform.position);
        }
    }
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Interact") && !isTalking)
            {
                player.canMove = false;
                isTalking = true;
                interactible.buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 0);
                //interactible.TextFading(0.01f);
                
                ActivateDialogueSettings(1);
            }
            else if (Input.GetButtonDown("Interact") && isTalking)
            {
                player.canMove = true;
                isTalking = false;
                interactible.buttonCanvas.transform.GetChild(0).GetComponent<Animator>().SetInteger("interactButton", 1);
                //interactible.TextFading(0.01f);
                ActivateDialogueSettings(0);
            }
            CutsceneCamera();
        }
    }

    void ActivateDialogueSettings(int setTrigger)
    {
        interactible.buttonCanvas.transform.GetChild(1).GetComponent<Animator>().SetInteger("speechBubble", setTrigger);
        if (setTrigger == 1)
        {
            interactible.StartCoroutine("TextDelay");
        }
        else {
            interactible.buttonCanvas.transform.GetChild(1).GetComponentInChildren<Text>().text = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>()) 
        {
            isInRange = true;
            isLooking = true;
        }
    }

        void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>())
        {
            isInRange = false;
        }
    }

    void CutsceneCamera() {
        if (isTalking)
        {
            if (transform.position.x <= player.transform.position.x)
            {
                cameraM.cameraState = CameraState.Left;
                cameraM.SetCameraTarget(transform);
            }
            else if (transform.position.x > player.transform.position.x) {
                cameraM.cameraState = CameraState.Right;
                cameraM.SetCameraTarget(transform);
            }
        }
        else if (!isTalking)
        {
            cameraM.cameraState = CameraState.Default;
        }
    }
}
