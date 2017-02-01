using UnityEngine;
using System.Collections;
public class PotBehaviour : MonoBehaviour {

    [HideInInspector] public bool activate;
    public GameObject heart;
    [Tooltip("The higher the number the lower the chance, example: 3 = 33%, 5 = 20%, 10 = 10% (NOTE: imput must be > 1)")]public int chance;

	void Update () {
        if (activate) {
            int chanceNum = Random.Range(1, chance);
            if (chanceNum == 1)
            {
                Instantiate(heart, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
	}
}
