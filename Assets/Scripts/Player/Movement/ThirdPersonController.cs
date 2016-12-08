using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

    /*[HideInInspector]*/ public float defaultSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canLookAround = true;


    public float turnSpeed = 3f;
    private float moveX, moveZ, lookX, lookZ;
    private HookshotController hookshotCtrl;
    private YouDead youDead;
    private Vector3 dir = Vector3.zero;
    private bool isGrounded;

    public bool isWalking
    {
        get; private set;
    }

    void Awake() {
        hookshotCtrl = GetComponent<HookshotController>();
        youDead = GetComponent<YouDead>();       
    }

    void Update ()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (canMove/* && youDead.isGrounded*/)
        {
            isWalking = moveX != 0 || moveZ != 0;
            transform.position += new Vector3(moveX, 0f, moveZ).normalized * defaultSpeed * Time.deltaTime;
        }
        if (canLookAround) {
            //if (Input.mousePresent)
            //{
                //Vector2 tempDir = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

                //dir = new Vector3(tempDir.x, 0, tempDir.y);

                //if (dir != Vector3.zero)
                //{
                //    transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * turnSpeed);
                //}
                Vector2 tempDir = new Vector2(moveX, moveZ).normalized;

                dir = new Vector3(tempDir.x, 0, tempDir.y);

                if (dir != Vector3.zero)
                {
                    transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * turnSpeed);
                }
            //}
        }
    }

    private void GetInput()
    {
        //if (youDead.isGrounded)
        //{
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
            lookX = Input.GetAxis("Horizontal(Rstick)");
            lookZ = Input.GetAxis("Vertical(Rstick)");
        //}
    }

    public void TowardsHookshotTarget(Transform hookedTarget) {
        transform.position = Vector3.MoveTowards(transform.position, hookedTarget.position, hookshotCtrl.shootingSpeed);
        float distance = Vector3.Distance(transform.position, hookedTarget.position);
        if (distance <= 1)
        {
            Destroy(hookedTarget.gameObject);
            hookshotCtrl.altweapons.canUseAltWeapon = true;
            hookshotCtrl.altweapons.swordAndShieldShowing = true;
            canMove = true;
            canLookAround = true;
            hookshotCtrl.currentState = HookshotState.Idle;
        }
    }
}
