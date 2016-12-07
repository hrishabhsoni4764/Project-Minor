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
        altweaponsOnScreen = AltWeaponsOnScreen.One;
        altWeapons = FindObjectOfType<AltWeapons>();
        altWeaponUIZero = GetComponent<AltWeaponUIZero>();
        altWeaponUIOne = GetComponent<AltWeaponUIOne>();
        altWeaponUITwo = GetComponent<AltWeaponUITwo>();
        altWeaponUIThree = GetComponent<AltWeaponUIThree>();
    }

    void Update() {
        switch (altweaponsOnScreen)
        {
            case AltWeaponsOnScreen.Zero:
                transform.GetChild(4).gameObject.SetActive(false);
                transform.GetChild(5).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(false);
                altWeaponUIZero.active = true;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.One:
                transform.GetChild(4).gameObject.SetActive(false);
                transform.GetChild(5).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(false);
                altWeaponUIZero.active = false;
                altWeaponUIOne.active = true;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.Two:
                transform.GetChild(4).gameObject.SetActive(true);
                transform.GetChild(5).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(false);
                altWeaponUIZero.active = false;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = true;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.Three:
                transform.GetChild(4).gameObject.SetActive(true);
                transform.GetChild(5).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(true);
                altWeaponUIZero.active = false;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = true;
                break;
        }
    }
}
