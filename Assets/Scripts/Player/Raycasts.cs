using UnityEngine;
using System.Collections;

public class Raycasts : MonoBehaviour {

    private Vector3 lastPosition;
    private MovingPlatform movingP;
    private TogglePlatform toggleP;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask movingPlatformLayer;
    [SerializeField] LayerMask togglePlatformLayer;

    [HideInInspector] public bool isGrounded;

    void Start() {
        movingP = FindObjectOfType<MovingPlatform>();
        toggleP = FindObjectOfType<TogglePlatform>();
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

        if (!GetComponent<PushBlock>())
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, movingPlatformLayer))
            {
                movingP.isParented = true;
            }
            else
            {
                movingP.isParented = false;
            }
        }
        else
        {
            if (transform.parent != GetComponent<ThirdPersonController>().transform) {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, togglePlatformLayer))
                {
                    transform.SetParent(hit.transform);
                }
                else
                {
                    transform.SetParent(null);
                }
            }
        }
    }

    public void Kill()
    {
        transform.position = lastPosition;
    }
}
