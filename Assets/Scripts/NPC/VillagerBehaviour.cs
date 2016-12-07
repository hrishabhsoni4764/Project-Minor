using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillagerBehaviour : MonoBehaviour {

    public string dialogueTextInput;
    public Animator blackBarsAnim;

    private GameObject dialoguePrompt;
    private ThirdPersonController player;
    private CameraMovement cameraM;

    [HideInInspector] public bool isLooking = false, isTalking = false, isInRange = false;

    void Start () {
        dialoguePrompt = GameManager.instance.dialoguePrompt;
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
            if (Input.GetButtonDown("Interact") && !isTalking)
            {
                player.canMove = false;
                isTalking = true;
                ActivateDialogueSettings();
            }
            else if (Input.GetButtonDown("Interact") && isTalking)
            {
                player.canMove = true;
                isTalking = false;
                dialoguePrompt.SetActive(false);
                if (isInRange)
                {
                    ActivateDialogueSettings();
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
            
            isInRange = true;
            isLooking = true;
        }
    }

        void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
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
