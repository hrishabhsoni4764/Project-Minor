using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillagerBehaviour : MonoBehaviour {

    public string dialogueTextInput, buttonTextInput;
    public Animator blackBarsAnim;

    private GameObject dialoguePrompt;
    private GameObject buttonPrompt;
    private ThirdPersonController player;
    private CameraMovement cameraM;

    [HideInInspector] public bool isLooking = false, isTalking = false, isInRange = false;

    void Start () {
        dialoguePrompt = GameManager.instance.dialoguePrompt;
        buttonPrompt = GameManager.instance.buttonPrompt;
        player = FindObjectOfType<ThirdPersonController>();
        cameraM = FindObjectOfType<CameraMovement>();
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
            if (Input.GetKeyDown(KeyCode.O) && !isTalking)
            {
                player.canMove = false;
                isTalking = true;
                buttonPrompt.SetActive(false);
                ActivateDialogueSettings();
            }
            else if (Input.GetKeyDown(KeyCode.O) && isTalking)
            {
                player.canMove = true;
                isTalking = false;
                dialoguePrompt.SetActive(false);
                if (isInRange)
                {
                    activateButtonSettings();
                }
            }
            CutsceneCamera();
        }
    }

    void ActivateDialogueSettings()
    {
        dialoguePrompt.SetActive(true);
        dialoguePrompt.GetComponentInChildren<Text>().text = (dialogueTextInput);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>()) 
        {
            activateButtonSettings();
            isInRange = true;
            isLooking = true;
        }
    }

        void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            buttonPrompt.SetActive(false);
            isInRange = false;
        }
    }

    void activateButtonSettings()
    {
        buttonPrompt.SetActive(true);
        buttonPrompt.GetComponentInChildren<Text>().text = buttonTextInput;
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
