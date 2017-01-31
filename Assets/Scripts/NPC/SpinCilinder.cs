using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCilinder : MonoBehaviour {

    private SpinnyBoss spinnyBoss;
    private bool canHit = true;

	void Start () {
        spinnyBoss = GetComponent<SpinnyBoss>();
	}
	
    void OnTriggerStay(Collider other) {
        if (other.GetComponent<AttackBehaviour>())
        {
            if (spinnyBoss.vulnarable && canHit)
            {
                canHit = false;
                spinnyBoss.health--;
                StartCoroutine("DamageTimer");
            }
        }
    }

    IEnumerator DamageTimer() {
        yield return new WaitForSeconds(.5f);
        canHit = true;
    }
}
