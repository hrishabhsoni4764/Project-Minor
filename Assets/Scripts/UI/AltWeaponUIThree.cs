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
                altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(4).GetComponent<Image>().sprite;
                transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 1f);
                transB = new Color(1f, 1f, 1f, 0.5f);
                transC = new Color(1f, 1f, 1f, 0.5f);
                if (Input.GetAxis("D-pad(Horizontal)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseThree.Boomerang;
                }
                else if (Input.GetAxis("D-pad(Vertical)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseThree.Bow;
                }
                break;
            case AltWeaponInUseThree.Boomerang:
                altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(5).GetComponent<Image>().sprite;
                transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 0.5f);
                transB = new Color(1f, 1f, 1f, 1f);
                transC = new Color(1f, 1f, 1f, 0.5f);
                if (Input.GetAxis("D-pad(Horizontal)") > 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseThree.Hookshot;
                }
                else if (Input.GetAxis("D-pad(Vertical)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseThree.Bow;
                }
                break;
            case AltWeaponInUseThree.Bow:
                altWeapons.weaponType = AltWeapons.WeaponType.Bow;
                transform.GetChild(7).GetComponent<Image>().sprite = transform.GetChild(6).GetComponent<Image>().sprite;
                transform.GetChild(7).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 0.5f);
                transB = new Color(1f, 1f, 1f, 0.5f);
                transC = new Color(1f, 1f, 1f, 1f);
                if (Input.GetAxis("D-pad(Horizontal)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseThree.Boomerang;
                }
                else if (Input.GetAxis("D-pad(Horizontal)") > 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseThree.Hookshot;
                }
                break;
        }
    }
}
