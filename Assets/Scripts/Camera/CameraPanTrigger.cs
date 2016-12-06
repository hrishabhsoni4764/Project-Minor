using UnityEngine;
using System.Collections;

public class CameraPanTrigger : MonoBehaviour {

    private CameraMovement cameraM;
    private bool isTriggered;
    public Transform target;
    public int height;
    public int pause;

	void Start () {
        cameraM = FindObjectOfType<CameraMovement>();
	}

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ThirdPersonController>() && !isTriggered) {
            cameraM.panTarget = target;
            cameraM.panHeight = height;
            cameraM.panPause = pause;
            cameraM.cameraState = CameraState.Pan;
            isTriggered = true;
            gameObject.SetActive(false);
        }
    }
}
