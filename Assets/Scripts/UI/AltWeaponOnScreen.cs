using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum AltWeaponsOnScreen { Zero, One, Two, Three }
public class AltWeaponOnScreen : MonoBehaviour {

    public AltWeaponsOnScreen altweaponsOnScreen;

    private AltWeapons altWeapons;
    private AltWeaponUIThree altWeaponUIThree;
    private AltWeaponUITwo altWeaponUITwo;
    private AltWeaponUIOne altWeaponUIOne;
    private AltWeaponUIZero altWeaponUIZero;

    void Start() {
        altWeapons = GameManager.instance.altWeapons;
        altWeaponUIZero = GetComponent<AltWeaponUIZero>();
        altWeaponUIOne = GetComponent<AltWeaponUIOne>();
        altWeaponUITwo = GetComponent<AltWeaponUITwo>();
        altWeaponUIThree = GetComponent<AltWeaponUIThree>();
    }

    void Update() {
        switch (altweaponsOnScreen)
        {
            case AltWeaponsOnScreen.Zero:
                transform.FindChild("Hook").gameObject.SetActive(false);
                transform.FindChild("Boom").gameObject.SetActive(false);
                transform.FindChild("Bow").gameObject.SetActive(false);
                altWeaponUIZero.active = true;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.One:
                transform.FindChild("Hook").gameObject.SetActive(false);
                transform.FindChild("Boom").gameObject.SetActive(true);
                transform.FindChild("Bow").gameObject.SetActive(false);
                altWeaponUIZero.active = false;
                altWeaponUIOne.active = true;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.Two:
                transform.FindChild("Hook").gameObject.SetActive(true);
                transform.FindChild("Boom").gameObject.SetActive(true);
                transform.FindChild("Bow").gameObject.SetActive(false);
                altWeaponUIZero.active = false;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = true;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.Three:
                transform.FindChild("Hook").gameObject.SetActive(true);
                transform.FindChild("Boom").gameObject.SetActive(true);
                transform.FindChild("Bow").gameObject.SetActive(true);
                altWeaponUIZero.active = false;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = true;
                break;
        }
    }
}
