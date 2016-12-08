using UnityEngine;
using System.Collections;

public class Raycasts : MonoBehaviour {

    private Vector3 lastPosition;
    private MovingPlatform movingP;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask movingPlatformLayer;

    [HideInInspector] public bool isGrounded;

    void Start() {
        movingP = FindObjectOfType<MovingPlatform>();
    }

	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, groundLayer))
        {
            isGrounded = true;
            lastPosition = transform.position;
        }
        else
        {
            isGrounded = false;
        }

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1, movingPlatformLayer))
        {
            movingP.isParented = true;
        }
        else
        {
            movingP.isParented = false;
        }
    }

    public void Kill()
    {
        transform.position = lastPosition;
    }
}
