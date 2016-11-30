using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIKey : MonoBehaviour {

    [HideInInspector] public static int keyAmount;

    void Update() {
        GetComponentInChildren<Text>().text = ("X " + keyAmount);
    }
}
