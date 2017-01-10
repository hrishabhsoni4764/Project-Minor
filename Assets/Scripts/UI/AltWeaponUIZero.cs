using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltWeaponUIZero : MonoBehaviour {

    private AltWeapons altWeapons;
    [HideInInspector] public bool active;

	void Start () {
        altWeapons = GameManager.instance.altWeapons;

    }
	
	void Update () {
        if (active)
        {
            altWeapons.weaponType = AltWeapons.WeaponType.Nothing;
            transform.FindChild("AltWeapon").GetComponent<Image>().sprite = null;
            transform.FindChild("AltWeapon").GetComponent<Image>().color = new Color(1f,1f,1f,0f);
        }
    }
}
