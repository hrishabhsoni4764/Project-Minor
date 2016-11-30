using UnityEngine;
using System.Collections;

public class CameraPanTrigger : MonoBehaviour {

    private CameraMovement cameraM;
    private bool isTriggered;

	void Start () {
        cameraM = FindObjectOfType<CameraMovement>();
	}

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ThirdPersonController>() && !isTriggered) {
            cameraM.cameraState = CameraState.Pan;
            isTriggered = true;
            gameObject.SetActive(false);
        }
    }
}
