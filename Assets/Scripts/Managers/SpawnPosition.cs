using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPosition : MonoBehaviour {

    public static int dungeonsBeaten;

    [HideInInspector] public Transform startPos;


	void Start () {

        AltWeaponOnScreen altOS = GameManager.instance.altOS;
        GameObject player = GameObject.FindObjectOfType<ThirdPersonController>().gameObject;

        Transform d0 = GameObject.Find("GameSpawn").transform;
        Transform d1 = GameObject.Find("Dungeon1Spawn").transform;
        Transform d2 = GameObject.Find("Dungeon2Spawn").transform;
        Transform d3 = GameObject.Find("Dungeon3Spawn").transform;

        if (SceneManager.GetActiveScene().name == "OutsideWorld")
        {
            if (dungeonsBeaten == 1)
            {
                startPos = d1;
                player.transform.position = startPos.position;
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.One;
            }
            else if (dungeonsBeaten == 2)
            {
                startPos = d2;
                player.transform.position = startPos.position;
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Two;
            }
            else if (dungeonsBeaten == 3)
            {
                startPos = d3;
                player.transform.position = startPos.position;
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Three;
            }
            else
            {
                startPos = d0;
                player.transform.position = startPos.position;
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Zero;
            }
        }
        else
        {
            if (dungeonsBeaten == 1)
            {
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.One;
            }
            else if (dungeonsBeaten == 2)
            {
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Two;
            }
            else if (dungeonsBeaten == 3)
            {
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Three;
            }
        }
    }

    void Update() {
        
    }
}
