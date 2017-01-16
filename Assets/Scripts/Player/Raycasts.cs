using UnityEngine;
using System.Collections;

public class Raycasts : MonoBehaviour {

    private Vector3 lastPosition;
    private MovingPlatform movingP;
    private ThirdPersonController tpc;
    private AltWeapons altWeapon;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask movingPlatformLayer;

    /*[HideInInspector]*/ public bool isGrounded;

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
            if (Physics.Raycast(transform.position + new Vector3(0.5f, 0f, 0f), Vector3.down, out hit, 1.5f, groundLayer) || Physics.Raycast(transform.position + new Vector3(-0.5f, 0f, 0f), Vector3.down, out hit, 1.5f, groundLayer) || Physics.Raycast(transform.position + new Vector3(0f, 0f, 0.5f), Vector3.down, out hit, 1.5f, groundLayer) || Physics.Raycast(transform.position + new Vector3(0f, 0f, -0.5f), Vector3.down, out hit, 1.5f, groundLayer))
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
        else {
            //PushBlockParenting//
            if (transform.parent != tpc.transform)
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, movingPlatformLayer))
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
        StartCoroutine("RespawnDelay");
    }

    IEnumerator RespawnDelay() {
        Animator fadeScreenAnim = GameManager.instance.fadeScreen.GetComponent<Animator>();
        fadeScreenAnim.SetInteger("fadeScreen", 1);
        yield return new WaitForSeconds(0.6f);
        fadeScreenAnim.SetInteger("fadeScreen", 0);
        //yield return new WaitForSeconds(1);
        Vector3 delta = (lastPosition - transform.position).normalized;
        delta.y = 0;
        transform.position = lastPosition + delta * 3f;
    }
}
