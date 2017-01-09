using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelection : MonoBehaviour {

    private DungeonRoomSel dR;

    void Start() {
        dR = FindObjectOfType<DungeonRooms>().dRS;
    }

    void OnTriggerStay(Collider other) {
        if (other.GetComponent<ThirdPersonController>()) {
            if (gameObject.name == "RoomSelection0")
            {
                dR = DungeonRoomSel.R0;
            }
            else if (gameObject.name == "RoomSelection1")
            {
                dR = DungeonRoomSel.R1;
            }
            else if (gameObject.name == "RoomSelection2")
            {
                dR = DungeonRoomSel.R2;
            }
            else if (gameObject.name == "RoomSelection3")
            {
                dR = DungeonRoomSel.R3;
            }
            else if (gameObject.name == "RoomSelection4")
            {
                dR = DungeonRoomSel.R4;
            }
            else if (gameObject.name == "RoomSelection5")
            {
                dR = DungeonRoomSel.R5;
            }
            else if (gameObject.name == "RoomSelection6")
            {
                dR = DungeonRoomSel.R6;
            }
        }
    }
}
