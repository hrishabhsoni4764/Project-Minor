using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIKey : MonoBehaviour {

    [HideInInspector] public static int keyAmount;
    [HideInInspector] public bool gotBossKey;

    void Update() {
        GetComponentInChildren<Text>().text = ("X " + keyAmount);
        if (gotBossKey)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
