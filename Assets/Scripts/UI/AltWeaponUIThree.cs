using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum AltWeaponInUseThree { Hookshot, Boomerang, Bow }
public class AltWeaponUIThree : MonoBehaviour {

    private Inventory inventory;
    private AltWeaponInUseThree altWeaponInUse;
    [HideInInspector] public bool active;

	void Start () {
        inventory = FindObjectOfType<Inventory>();
	}
	
	void Update () {
        if (active)
        {
            if (!inventory.inventoryIsShowing)
            {
                UpdateImages();
            }
        }
    }

    void UpdateImages() {
        switch (altWeaponInUse)
        {
            case AltWeaponInUseThree.Hookshot:
                inventory.altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                gameObject.transform.GetChild(2).GetComponent<Image>().sprite = inventory.altweaponIcons[0].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.altweaponIcons[2].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(1).GetComponent<Image>().sprite = inventory.altweaponIcons[1].GetComponent<Image>().sprite;
                if (inventory.altWeapons.canUseAltWeapon)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetAxis("Mouse ScrollWheel") > 0) {
                        altWeaponInUse = AltWeaponInUseThree.Boomerang;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetAxis("Mouse ScrollWheel") < 0) {
                        altWeaponInUse = AltWeaponInUseThree.Bow;
                    }
                }
                break;
            case AltWeaponInUseThree.Boomerang:
                inventory.altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                gameObject.transform.GetChild(2).GetComponent<Image>().sprite = inventory.altweaponIcons[1].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.altweaponIcons[0].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(1).GetComponent<Image>().sprite = inventory.altweaponIcons[2].GetComponent<Image>().sprite;
                if (inventory.altWeapons.canUseAltWeapon)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        altWeaponInUse = AltWeaponInUseThree.Hookshot;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        altWeaponInUse = AltWeaponInUseThree.Bow;
                    }
                }
                break;
            case AltWeaponInUseThree.Bow:
                inventory.altWeapons.weaponType = AltWeapons.WeaponType.Bow;
                gameObject.transform.GetChild(2).GetComponent<Image>().sprite = inventory.altweaponIcons[2].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.altweaponIcons[1].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(1).GetComponent<Image>().sprite = inventory.altweaponIcons[0].GetComponent<Image>().sprite;
                if (inventory.altWeapons.canUseAltWeapon)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        altWeaponInUse = AltWeaponInUseThree.Hookshot;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        altWeaponInUse = AltWeaponInUseThree.Boomerang;
                    }
                }
                break;
        }
    }
}
