using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum AltWeaponInUseTwo { Hookshot, Boomerang }
public class AltWeaponUITwo : MonoBehaviour {

    private Inventory inventory;
    private AltWeaponInUseTwo altWeaponInUse;
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
            case AltWeaponInUseTwo.Hookshot:
                inventory.altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.altweaponIcons[1].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(1).GetComponent<Image>().sprite = inventory.altweaponIcons[0].GetComponent<Image>().sprite;
                if (inventory.altWeapons.canUseAltWeapon)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        altWeaponInUse = AltWeaponInUseTwo.Boomerang;
                    }
                }
                break;
            case AltWeaponInUseTwo.Boomerang:
                inventory.altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.altweaponIcons[0].GetComponent<Image>().sprite;
                gameObject.transform.GetChild(1).GetComponent<Image>().sprite = inventory.altweaponIcons[1].GetComponent<Image>().sprite;
                if (inventory.altWeapons.canUseAltWeapon)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        altWeaponInUse = AltWeaponInUseTwo.Hookshot;
                    }
                }
                break;
        }
    }
}
