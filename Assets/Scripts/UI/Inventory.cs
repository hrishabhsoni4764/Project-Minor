using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public enum SelectedAltweapon { Hookshot, Boomerang, Bow };

    [HideInInspector] public bool inventoryIsShowing;
    private bool hookshotIsShowing, boomerangIsShowing, bowIsShowing;
    [HideInInspector] public AltWeapons altWeapons;
    private GameObject fadeOverlay;
    private GameObject inventory;

    public GameObject[] altweaponIcons;
    public GameObject[] selectBrackets;

    [HideInInspector] public SelectedAltweapon selectedAlt;

    void Start () {
        inventory = GameManager.instance.inventory;
        fadeOverlay = GameManager.instance.fadeOverlay;
        altWeapons = FindObjectOfType<AltWeapons>();
        hookshotIsShowing = true;
        boomerangIsShowing = true;
        bowIsShowing = true;
    }
	
	void Update () {
     
	}

    void AltweaponsShowing() {

        if (hookshotIsShowing)
        {
            altweaponIcons[0].SetActive(true);
        }
        else {
            altweaponIcons[0].SetActive(false);
        }

        if (boomerangIsShowing)
        {
            altweaponIcons[1].SetActive(true);
        }
        else {
            altweaponIcons[1].SetActive(false);
        }

        if (bowIsShowing)
        {
            altweaponIcons[2].SetActive(true);
        }
        else {
            altweaponIcons[2].SetActive(false);
        }

    }

    void SelectAlt() {
        switch (selectedAlt)
        {
            case SelectedAltweapon.Hookshot:
                selectBrackets[0].SetActive(true);
                selectBrackets[1].SetActive(false);
                selectBrackets[2].SetActive(false);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    selectedAlt = SelectedAltweapon.Boomerang;
                } else if (Input.GetKeyDown(KeyCode.A)) {
                    selectedAlt = SelectedAltweapon.Bow;
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                    altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                }
                    break;
            case SelectedAltweapon.Boomerang:
                selectBrackets[0].SetActive(false);
                selectBrackets[1].SetActive(true);
                selectBrackets[2].SetActive(false);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    selectedAlt = SelectedAltweapon.Bow;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    selectedAlt = SelectedAltweapon.Hookshot;
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                }
                break;
            case SelectedAltweapon.Bow:
                selectBrackets[0].SetActive(false);
                selectBrackets[1].SetActive(false);
                selectBrackets[2].SetActive(true);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    selectedAlt = SelectedAltweapon.Hookshot;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    selectedAlt = SelectedAltweapon.Boomerang;
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    altWeapons.weaponType = AltWeapons.WeaponType.Bow;
                }
                break;
        }
    }
}
