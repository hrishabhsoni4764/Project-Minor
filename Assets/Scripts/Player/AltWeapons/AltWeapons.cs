using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltWeapons : MonoBehaviour {

    public GameObject[] altWeapons;

    [HideInInspector] public bool canUseAltWeapon = true;
    [HideInInspector] public bool swordAndShieldShowing = true;
    [HideInInspector] public HookshotController hookshot;
    [HideInInspector] public BoomerangController boomerang;
    [HideInInspector] public BowController bow;
    [HideInInspector] public Vector3 altWeaponPos;
    [HideInInspector] public ThirdPersonController tpc;
    private AltWeaponOnScreen altOS;
    private Sprite altWeaponSprite;
    public enum WeaponType {
        Hookshot,
        Boomerang,
        Bow,
        Nothing
    }
    /*[HideInInspector] */public WeaponType weaponType;

    void Start() {
        tpc = GetComponent<ThirdPersonController>();
        altOS = FindObjectOfType<AltWeaponOnScreen>();
        hookshot = GetComponent<HookshotController>();
        hookshot.altweapons = this;
        boomerang = GetComponent<BoomerangController>();
        boomerang.altweapons = this;
        bow = GetComponent<BowController>();
        bow.altweapons = this;
    }

    void Update() {
        altWeaponPos = transform.position + transform.forward;
        SelectAltWeapon();
        if (swordAndShieldShowing)
        {
            tpc.transform.GetChild(5).GetComponent<MeshRenderer>().enabled = true;
            tpc.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = true;
            altOS.transform.GetChild(2).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            altOS.transform.GetChild(3).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else {
            tpc.transform.GetChild(5).GetComponent<MeshRenderer>().enabled = false;
            tpc.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = false;
            altOS.transform.GetChild(2).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            altOS.transform.GetChild(3).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

    void SelectAltWeapon() {
        switch (weaponType) {
            case WeaponType.Hookshot:
                hookshot.active = true;
                bow.active = false;
                boomerang.active = false;
                break;
            case WeaponType.Boomerang:
                hookshot.active = false;
                boomerang.active = true;
                bow.active = false;
                break;
            case WeaponType.Bow:
                bow.active = true;
                hookshot.active = false;
                boomerang.active = false;
                break;
            case WeaponType.Nothing:
                hookshot.active = false;
                bow.active = false;
                boomerang.active = false;
                break;
        }
    }
}
