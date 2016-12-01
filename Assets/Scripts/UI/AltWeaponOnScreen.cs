using UnityEngine;
using System.Collections;

public enum AltWeaponsOnScreen { Three, Two, One, Zero }
public class AltWeaponOnScreen : MonoBehaviour {

    public AltWeaponsOnScreen altweaponsOnScreen;
    public GameObject[] Slots;

    private AltWeaponUIThree altWeaponUIThree;
    private AltWeaponUITwo altWeaponUITwo;
    private AltWeaponUIOne altWeaponUIOne;
    private AltWeaponUIZero altWeaponUIZero;

    void Start() {
        altWeaponUIThree = gameObject.transform.GetChild(0).GetComponent<AltWeaponUIThree>();
        altWeaponUITwo = gameObject.transform.GetChild(1).GetComponent<AltWeaponUITwo>();
        altWeaponUIOne = gameObject.transform.GetChild(2).GetComponent<AltWeaponUIOne>();
        altWeaponUIZero = gameObject.transform.GetChild(2).GetComponent<AltWeaponUIZero>();
    }

    void Update() {
        switch (altweaponsOnScreen)
        {
            case AltWeaponsOnScreen.Zero:
                Slots[0].SetActive(true);
                Slots[1].SetActive(false);
                Slots[2].SetActive(false);
                altWeaponUIZero.active = true;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = false;
                break;
            case AltWeaponsOnScreen.One:
                Slots[0].SetActive(true);
                Slots[1].SetActive(false);
                Slots[2].SetActive(false);
                altWeaponUIOne.active = true;
                altWeaponUITwo.active = false;
                altWeaponUIThree.active = false;
                altWeaponUIZero.active = false;
                break;
            case AltWeaponsOnScreen.Two:
                Slots[0].SetActive(false);
                Slots[1].SetActive(true);
                Slots[2].SetActive(false);
                altWeaponUITwo.active = true;
                altWeaponUIOne.active = false;
                altWeaponUIThree.active = false;
                altWeaponUIZero.active = false;
                break;
            case AltWeaponsOnScreen.Three:
                Slots[0].SetActive(false);
                Slots[1].SetActive(false);
                Slots[2].SetActive(true);
                altWeaponUIThree.active = true;
                altWeaponUIOne.active = false;
                altWeaponUITwo.active = false;
                altWeaponUIZero.active = false;
                break;
        }
    }
}
