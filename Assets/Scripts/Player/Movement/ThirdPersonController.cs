using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

    /*[HideInInspector]*/ public float defaultSpeed;
    /*[HideInInspector]*/ public float sprintSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canLookAround = true;


    private float turnSpeed = 3f;
    private float moveX, moveZ;
    private HookshotController hookshotCtrl;
    private Vector3 dir = Vector3.zero;
    
    public bool isWalking
    {
        get; private set;
    }

    void Start() {
        hookshotCtrl = GetComponent<HookshotController>();
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
        if (canMove)
        {
            isWalking = moveX != 0 || moveZ != 0;
            transform.position += new Vector3(moveX, 0f, moveZ).normalized * currentSpeed * Time.deltaTime;

            Sprinting();
        }
        if (canLookAround) {
            Vector2 tempDir = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

            dir = new Vector3(tempDir.x, 0, tempDir.y);

            if (dir != Vector3.zero)
            {
                transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * turnSpeed);
            }
        }
    }

    private void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    void Sprinting() {
        if (Input.GetKey(KeyCode.LeftShift) && isWalking)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = defaultSpeed;
        }
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
