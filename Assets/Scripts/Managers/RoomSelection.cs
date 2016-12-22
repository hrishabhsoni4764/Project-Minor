using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelection : MonoBehaviour {

    private Dungeon3Rooms dR;

    void Start() {
        dR = FindObjectOfType<DungeonRooms>().d3R;
    }

    void OnTriggerStay(Collider other) {
        if (other.GetComponent<ThirdPersonController>()) {
            if (gameObject.name == "RoomSelection0")
            {
                dR = Dungeon3Rooms.R0;
            }
            else if (gameObject.name == "RoomSelection1")
            {
                dR = Dungeon3Rooms.R1;
            }
            else if (gameObject.name == "RoomSelection2")
            {
                dR = Dungeon3Rooms.R2;
            }
            else if (gameObject.name == "RoomSelection3")
            {
                dR = Dungeon3Rooms.R3;
            }
            else if (gameObject.name == "RoomSelection4")
            {
                dR = Dungeon3Rooms.R4;
            }
            else if (gameObject.name == "RoomSelection5")
            {
                dR = Dungeon3Rooms.R5;
            }
            else if (gameObject.name == "RoomSelection6")
            {
                dR = Dungeon3Rooms.R6;
            }
        }
    }
}
