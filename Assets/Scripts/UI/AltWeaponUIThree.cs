using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum AltWeaponInUseThree { Hookshot, Boomerang, Bow }
public class AltWeaponUIThree : MonoBehaviour {

    private AltWeapons altWeapons;
    private AltWeaponInUseThree altWeaponInUse;
    [HideInInspector] public bool active;

	void Start () {
        altWeapons = FindObjectOfType<AltWeapons>();
	}
	
	void Update () {
        if (active)
        {
            UpdateImages();
        }
    }

    void UpdateImages() {
        Color transA = transform.GetChild(4).GetComponent<Image>().color;
        Color transB = transform.GetChild(5).GetComponent<Image>().color;
        Color transC = transform.GetChild(6).GetComponent<Image>().color;
        switch (altWeaponInUse)
        {
            case AltWeaponInUseThree.Hookshot:
                transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(4).GetComponent<Image>().sprite;
                transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 1f);
                transB = new Color(1f, 1f, 1f, 0.3f);
                transC = new Color(1f, 1f, 1f, 0.3f);
                if (Input.GetAxis("D-pad(Horizontal)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                }
                else if (Input.GetAxis("D-pad(Vertical)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Bow;
                }
                else {
                    altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                }
                break;
            case AltWeaponInUseThree.Boomerang:
                transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(5).GetComponent<Image>().sprite;
                transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 0.3f);
                transB = new Color(1f, 1f, 1f, 1f);
                transC = new Color(1f, 1f, 1f, 0.3f);
                if (Input.GetAxis("D-pad(Horizontal)") > 0 && altWeapons.canUseAltWeapon)
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                }
                else if (Input.GetAxis("D-pad(Vertical)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Bow;
                }
                else {
                    altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                }
                break;
            case AltWeaponInUseThree.Bow:
                transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(6).GetComponent<Image>().sprite;
                transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 0.3f);
                transB = new Color(1f, 1f, 1f, 0.3f);
                transC = new Color(1f, 1f, 1f, 1f);
                if (Input.GetAxis("D-pad(Horizontal)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                }
                else if (Input.GetAxis("D-pad(Horizontal)") > 0 && altWeapons.canUseAltWeapon)
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                }
                else {
                    altWeapons.weaponType = AltWeapons.WeaponType.Bow;
                }
                break;
        }
    }
}
