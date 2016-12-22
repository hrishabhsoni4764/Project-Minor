﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Dungeon3Rooms {R0,R1,R2,R3,R4,R5,R6}
public class DungeonRooms : MonoBehaviour {

    public Dungeon3Rooms d3R;

	void Start () {
        d3R = Dungeon3Rooms.R6;
	}
	
	void Update () {
        SceneCheck();
	}

    void SceneCheck() {
        if (SceneManager.GetActiveScene().name == "Dungeon3")
        {
            GameObject[] rooms = new GameObject[7];
            rooms[0] = GameObject.Find("Rooms").transform.GetChild(0).gameObject;
            rooms[1] = GameObject.Find("Rooms").transform.GetChild(1).gameObject;
            rooms[2] = GameObject.Find("Rooms").transform.GetChild(2).gameObject;
            rooms[3] = GameObject.Find("Rooms").transform.GetChild(3).gameObject;
            rooms[4] = GameObject.Find("Rooms").transform.GetChild(4).gameObject;
            rooms[5] = GameObject.Find("Rooms").transform.GetChild(5).gameObject;
            rooms[6] = GameObject.Find("Rooms").transform.GetChild(6).gameObject;
            switch (d3R)
            {
                case Dungeon3Rooms.R0:
                    rooms[0].SetActive(true);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case Dungeon3Rooms.R1:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(true);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case Dungeon3Rooms.R2:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(true);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case Dungeon3Rooms.R3:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(true);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case Dungeon3Rooms.R4:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(true);
                    rooms[5].SetActive(false);
                    rooms[6].SetActive(false);
                    break;
                case Dungeon3Rooms.R5:
                    rooms[0].SetActive(false);
                    rooms[1].SetActive(false);
                    rooms[2].SetActive(false);
                    rooms[3].SetActive(false);
                    rooms[4].SetActive(false);
                    rooms[5].SetActive(true);
                    rooms[6].SetActive(false);
                    break;
                case Dungeon3Rooms.R6:
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
        else if (SceneManager.GetActiveScene().name == "Dungeon2")
        {

        }
    }
}
