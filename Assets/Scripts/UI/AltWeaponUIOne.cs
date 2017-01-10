using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltWeaponUIOne : MonoBehaviour {

    private AltWeapons altWeapons;
    [HideInInspector] public bool active;

	void Start () {
        altWeapons = GameManager.instance.altWeapons;
    }

    void Update () {
        if (active) {
            altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
            transform.FindChild("AltWeapon").GetComponent<Image>().sprite = transform.FindChild("Boom").GetComponent<Image>().sprite;
            transform.FindChild("AltWeapon").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
