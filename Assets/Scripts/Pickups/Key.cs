using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    private UIKey uiKey;

    void Start() {
        uiKey = GameManager.instance.uiKey;
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ThirdPersonController>()) {
            UIKey.keyAmount++;
            Destroy(this.gameObject);
        }
    }
}
