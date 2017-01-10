using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum AltWeaponInUseTwo { Hookshot, Boomerang }
public class AltWeaponUITwo : MonoBehaviour {

    private AltWeapons altWeapons;
    private AltWeaponInUseTwo altWeaponInUse;
    [HideInInspector] public bool active;

	void Start () {
        altWeapons = GameManager.instance.altWeapons;
	}
	
	void Update () {
        if (active)
        {
            UpdateImages();
        }
    }

    void UpdateImages() {
        Color transA = transform.FindChild("Hook").GetComponent<Image>().color;
        Color transB = transform.FindChild("Boom").GetComponent<Image>().color;
        switch (altWeaponInUse)
        {
            case AltWeaponInUseTwo.Hookshot:
                altWeapons.weaponType = AltWeapons.WeaponType.Hookshot;
                transform.FindChild("AltWeapon").GetComponent<Image>().sprite = transform.FindChild("Hook").GetComponent<Image>().sprite;
                transform.FindChild("AltWeapon").GetComponent<Image>().color = new Color(1f,1f,1f,1f);
                transA = new Color(1f, 1f, 1f, 1f);
                transB = new Color(1f, 1f, 1f, 0.5f);
                if (Input.GetAxis("D-pad(Horizontal)") < 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseTwo.Boomerang;
                }
                break;
            case AltWeaponInUseTwo.Boomerang:
                altWeapons.weaponType = AltWeapons.WeaponType.Boomerang;
                transform.FindChild("AltWeapon").GetComponent<Image>().sprite = transform.FindChild("Boom").GetComponent<Image>().sprite;
                transform.FindChild("AltWeapon").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                transA = new Color(1f, 1f, 1f, 0.5f);
                transB = new Color(1f, 1f, 1f, 1f);
                if (Input.GetAxis("D-pad(Horizontal)") > 0 && altWeapons.canUseAltWeapon)
                {
                    altWeaponInUse = AltWeaponInUseTwo.Hookshot;
                }
                break;
        }
    }
}
