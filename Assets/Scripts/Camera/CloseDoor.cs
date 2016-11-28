using UnityEngine;
using System.Collections;

public class CloseDoor : MonoBehaviour {

    public GameObject door;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            door.SetActive(true);
        }
    }

}
