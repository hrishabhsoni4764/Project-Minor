using UnityEngine;
using System.Collections;
public class PotBehaviour : MonoBehaviour {

    [HideInInspector] public bool activate;
    public GameObject heart;

	void Update () {
        if (activate) {
            Instantiate(heart, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
