using UnityEngine;
using System.Collections;

public class Raycasts : MonoBehaviour {

    private Vector3 lastPosition;
    private MovingPlatform movingP;
    private ThirdPersonController tpc;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask movingPlatformLayer;

    [HideInInspector] public bool isGrounded;

    void Start() {
        movingP = GameManager.instance.movingP;
        tpc = GameManager.instance.tpc;
    }

    void Update()
    {
        RaycastHit hit;
        if (!GetComponent<PushBlock>())
        {
            //MovingPlatform//
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 3, movingPlatformLayer))
            {
                transform.SetParent(hit.collider.transform);
            }
            else
            {
                transform.SetParent(null);
            }

            //KillBox//
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, groundLayer))
            {
                isGrounded = true;
                lastPosition = transform.position;
            }
            else
            {
                isGrounded = false;
            }
        }

            //    //PushBlockParenting//
            //    if (transform.parent != tpc.transform) {
            //        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, togglePlatformLayer))
            //        {
            //            transform.SetParent(hit.transform);
            //        }
            //        else
            //        {
            //            transform.SetParent(null);
            //        }
            //    }
            //}
    }

    public void Kill()
    {
        transform.position = lastPosition;
    }
}
