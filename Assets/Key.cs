using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public GameObject doorToOpen;

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ThirdPersonController>()) {
            doorToOpen.GetComponent<RoomDoorScript>().active = true;
            Destroy(this.gameObject);
        }
    }
}
