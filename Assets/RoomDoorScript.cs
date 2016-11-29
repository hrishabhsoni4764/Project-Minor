using UnityEngine;
using System.Collections;

public class RoomDoorScript : MonoBehaviour {

    [HideInInspector] public bool active = false;

	void Update () {
        if (active) {
            GetComponent<BoxCollider>().isTrigger = true;
        }
	}
}
