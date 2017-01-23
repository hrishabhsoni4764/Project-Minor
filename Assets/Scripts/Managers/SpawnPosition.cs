using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPosition : MonoBehaviour {

    public static int dungeonsBeaten;

    [HideInInspector] public Transform startPos;


	void Start () {
        AltWeaponOnScreen altOS = GameManager.instance.altOS;
        GameObject player = GameManager.instance.tpc.gameObject;

        if (SceneManager.GetActiveScene().name == "OutsideWorld")
        {
            Transform d0 = GameManager.instance.spawnpoints[0].transform;
            Transform d1 = GameManager.instance.spawnpoints[1].transform;
            Transform d2 = GameManager.instance.spawnpoints[2].transform;
            Transform d3 = GameManager.instance.spawnpoints[3].transform;

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
            else
            {
                altOS.altweaponsOnScreen = AltWeaponsOnScreen.Zero;
            }
        }
    }

    void Update() {
        
    }
}
