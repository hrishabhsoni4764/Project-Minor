﻿using UnityEngine;
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
    [HideInInspector] public WeaponType weaponType;

    void Start() {
        tpc = GameManager.instance.tpc;
        altOS = GameManager.instance.altOS;
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
            tpc.transform.FindChild("Sword").GetComponent<MeshRenderer>().enabled = true;
            tpc.transform.FindChild("Shield").GetComponent<MeshRenderer>().enabled = true;
            altOS.transform.FindChild("Sword").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            altOS.transform.FindChild("Shield").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else {
            tpc.transform.FindChild("Sword").GetComponent<MeshRenderer>().enabled = false;
            tpc.transform.FindChild("Shield").GetComponent<MeshRenderer>().enabled = false;
            altOS.transform.FindChild("Sword").GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            altOS.transform.FindChild("Shield").GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (canUseAltWeapon)
        {
            altOS.transform.FindChild("AltWeapon").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else {
            altOS.transform.FindChild("AltWeapon").GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
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
