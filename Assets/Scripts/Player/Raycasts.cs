using UnityEngine;
using System.Collections;

public class Raycasts : MonoBehaviour {

    private Vector3 lastPosition;
    private MovingPlatform movingP;
    private ThirdPersonController tpc;
    private AltWeapons altWeapon;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask movingPlatformLayer;

    [HideInInspector] public bool isGrounded;

    void Start() {
        movingP = GameManager.instance.movingP;
        tpc = GameManager.instance.tpc;
        altWeapon = GameManager.instance.altWeapons;
    }

    void Update()
    {
        RaycastHit hit;

        if (!GetComponent<PushBlock>())
        {
            //MovingPlatform//
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f, movingPlatformLayer))
            {
                transform.SetParent(hit.collider.transform);
            }
            else
            {
                transform.SetParent(null);
            }

            //KillBox//
            if (Physics.SphereCast(transform.position, transform.GetComponent<CapsuleCollider>().radius, Vector3.down, out hit, 1, groundLayer))
            {
                isGrounded = true;
                tpc.canMove = true;
                tpc.canLookAround = true;
                altWeapon.canUseAltWeapon = true;
                lastPosition = transform.position;
            }
            else
            {
                tpc.canMove = false;
                tpc.canLookAround = false;
                altWeapon.canUseAltWeapon = false;
                isGrounded = false;
            }
        }
        else
        {
            //PushBlockParenting//
            if (transform.parent.parent != tpc.transform)
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, movingPlatformLayer))
                {
                    transform.parent.SetParent(hit.transform);
                }
                else
                {
                    transform.parent.SetParent(GetComponent<PushBlock>().originParent.transform);
                }
            }
        }
    }

    public void Kill()
    {
        StartCoroutine("RespawnDelay");
    }

    IEnumerator RespawnDelay() {
        Animator fadeScreenAnim = GameManager.instance.fadeScreen.GetComponent<Animator>();
        fadeScreenAnim.SetInteger("fadeScreen", 1);
        yield return new WaitForSeconds(0.6f);
        fadeScreenAnim.SetInteger("fadeScreen", 0);
        Vector3 delta = (lastPosition - transform.position).normalized;
        delta.y = 0;
        transform.position = lastPosition + delta * 3f;
    }

    void OnDrawGizmos()
    {
        if (GetComponent<PushBlock>())
        {
            //Gizmos.DrawSphere(transform.position, 0.5f);
            //Gizmos.DrawCube(transform.position, new Vector3(1f, .5f, 1f));
            //Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
        }
    }
}
