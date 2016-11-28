using UnityEngine;
using System.Collections;

public class CameraPosChange : MonoBehaviour {

    private CameraMovement cameraM;

    void Start() {
        cameraM = FindObjectOfType<CameraMovement>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            cameraM.cameraState = CameraState.Behind;
        }
    }
}
