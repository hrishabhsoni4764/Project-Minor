using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltWeaponUIOne : MonoBehaviour {

    private AltWeapons altWeapons;
    [HideInInspector] public bool active;

	void Start () {
        altWeapons = FindObjectOfType<AltWeapons>();
	}
	
	void Update () {
        if (active) {
            altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
            transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(5).GetComponent<Image>().sprite;
            transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
