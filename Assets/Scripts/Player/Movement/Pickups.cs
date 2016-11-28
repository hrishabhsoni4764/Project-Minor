﻿using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

    private PlayerBehaviour playerB;

	void Start () {
        playerB = FindObjectOfType<PlayerBehaviour>();
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Heart")) {
                playerB.RestoreHealth(1);
                Destroy(other.gameObject);
        }
    }
}
