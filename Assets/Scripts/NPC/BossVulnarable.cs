using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVulnarable : MonoBehaviour {

    [HideInInspector] public bool activateSwitch;
    private bool toggle;
    private SpinnyBoss spinnyBoss;

	void Start () {
        spinnyBoss = GameManager.instance.spinnyBoss;
	}
	
	void Update () {
        if (activateSwitch) {
            if (!toggle) {
                toggle = true;
                if (spinnyBoss.bossStates == BossStates.one)
                {
                    spinnyBoss.active = false;
                    StartCoroutine("BossVul");
                }
                else if (spinnyBoss.bossStates == BossStates.two)
                {
                    spinnyBoss.active = false;
                    StartCoroutine("BossVul");
                }
                else if (spinnyBoss.bossStates == BossStates.three)
                {
                    spinnyBoss.active = false;
                    StartCoroutine("BossVul");
                }
            }
        }
	}

    IEnumerator BossVul() {
        yield return new WaitForSeconds(3);
        spinnyBoss.active = true;
        activateSwitch = false;
        toggle = false;
    }
}
