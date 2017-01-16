using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum DungeonRoomSel {R0,R1,R2,R3,R4,R5,R6}
public class DungeonRooms : MonoBehaviour {

    [HideInInspector] public DungeonRoomSel dRS;
    public int startRoom;
    [HideInInspector] public bool activate;

	void Start () {
        dRS = (DungeonRoomSel)startRoom;
    }
	
	void Update () {
        if (activate)
        {
            SceneCheck();
            activate = false;
        }
	}

    void SceneCheck() {
        if (SceneManager.GetActiveScene().name == "Dungeon2")
        {
            GameObject[] rooms = new GameObject[7];
            rooms[0] = GameManager.instance.currentRooms.transform.GetChild(0).gameObject;
            rooms[1] = GameManager.instance.currentRooms.transform.GetChild(1).gameObject;
            rooms[2] = GameManager.instance.currentRooms.transform.GetChild(2).gameObject;
            rooms[3] = GameManager.instance.currentRooms.transform.GetChild(3).gameObject;
            rooms[4] = GameManager.instance.currentRooms.transform.GetChild(4).gameObject;
            rooms[5] = GameManager.instance.currentRooms.transform.GetChild(5).gameObject;
            rooms[6] = GameManager.instance.currentRooms.transform.GetChild(6).gameObject;
            switch (dRS)
            {
                case DungeonRoomSel.R0:
                    rooms[0].SetActive(true);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case DungeonRoomSel.R1:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(true);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case DungeonRoomSel.R2:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(true);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case DungeonRoomSel.R3:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(true);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case DungeonRoomSel.R4:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(true);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case DungeonRoomSel.R5:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(true);
                    rooms[6].SetActive(false);
                    break;
                case DungeonRoomSel.R6:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(true);
                    break;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Dungeon1")
        {
            GameObject[] rooms = new GameObject[6];
            rooms[0] = GameManager.instance.currentRooms.transform.GetChild(0).gameObject;
            rooms[1] = GameManager.instance.currentRooms.transform.GetChild(1).gameObject;
            rooms[2] = GameManager.instance.currentRooms.transform.GetChild(2).gameObject;
            rooms[3] = GameManager.instance.currentRooms.transform.GetChild(3).gameObject;
            rooms[4] = GameManager.instance.currentRooms.transform.GetChild(4).gameObject;
            rooms[5] = GameManager.instance.currentRooms.transform.GetChild(5).gameObject;
            switch (dRS)
            {
                case DungeonRoomSel.R0:
                    rooms[0].SetActive(true);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    break;
                case DungeonRoomSel.R1:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(true);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    break;
                case DungeonRoomSel.R2:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(true);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    break;
                case DungeonRoomSel.R3:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(true);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    break;
                case DungeonRoomSel.R4:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(true);
                    rooms[5].SetActive(false);
                    break;
                case DungeonRoomSel.R5:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(true);
                    break;
                case DungeonRoomSel.R6:
                    
                    break;
            }
        }
    }
}
