using UnityEngine;
using System.Collections;

public class YouDead : MonoBehaviour {

    private Vector3 lastPosition;
    [SerializeField] LayerMask layer;

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, layer))
        {
            Debug.Log("Ground Found");
            lastPosition = transform.position;
        }
	}

    public void Kill()
    {
        transform.position = lastPosition;
    }
}
