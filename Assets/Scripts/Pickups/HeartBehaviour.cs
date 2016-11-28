using UnityEngine;
using System.Collections;

public class HeartBehaviour : MonoBehaviour {


	void Start () {
        StartCoroutine("HeartDisappear");
	}

    IEnumerator HeartDisappear() {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

}
