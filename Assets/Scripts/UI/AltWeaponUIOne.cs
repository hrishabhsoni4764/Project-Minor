using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltWeaponUIOne : MonoBehaviour {

    private Inventory inventory;
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
        inventory.altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.altweaponIcons[1].GetComponent<Image>().sprite;
        gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }
}
