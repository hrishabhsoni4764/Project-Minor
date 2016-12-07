using UnityEngine;
using System.Collections;

public class YouDead : MonoBehaviour {

    private Vector3 lastPosition;
    [SerializeField] LayerMask layer;

    [HideInInspector] public bool isGrounded;

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, layer))
        {
            isGrounded = true;
            lastPosition = transform.position;
        }
        else {
            isGrounded = false;
        }
	}

    public void Kill()
    {
        transform.position = lastPosition;
    }
}
