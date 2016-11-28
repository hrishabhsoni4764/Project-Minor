using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

    void Start() {
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.gameObject.CompareTag("Player") && other.collider.gameObject.GetComponent<ThirdPersonController>().currentSpeed == other.collider.gameObject.GetComponent<ThirdPersonController>().sprintSpeed) {
            GetComponentInChildren<Animator>().SetTrigger("ShakeLeaves");
        }
    }
}
