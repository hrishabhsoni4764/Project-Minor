using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyBlades : MonoBehaviour {

    private PlayerBehaviour playerB;
    private bool canHurt = true;

	void Start () {
        playerB = GameManager.instance.playerB;
	}
	
	void Update () {

	}

    void OnTriggerStay(Collider other) {
        if (other.GetComponent<ThirdPersonController>() && !other.GetComponent<SphereCollider>() && canHurt) {
            playerB.curHealth -= 1;
            playerB.PlayerBounceBack(this.transform, 10f);
            canHurt = false;
            StartCoroutine("GetHurtDelay");
        }
    }

    IEnumerator GetHurtDelay() {
        yield return new WaitForSeconds(1);
        canHurt = true;
    }
}
