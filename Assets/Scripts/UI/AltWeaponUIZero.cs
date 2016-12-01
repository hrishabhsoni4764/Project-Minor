using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltWeaponUIZero : MonoBehaviour {

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
        inventory.altWeapons.weaponType = AltWeapons.WeaponType.Nothing;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
        /*Color slotColor = */
        gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(0f,0f,0f,0f);
        //slotColor.a = 0f;
    }
}
