using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum CameraState { Default, Left, Right, Behind, Pan, Static }
public class CameraMovement : MonoBehaviour
{
    [Header ("-Pan Options-")]
    [HideInInspector] public float panHeight;
    [HideInInspector] public int panPause;
    [HideInInspector] public Transform panTarget;

    [Header("-Animations-")]
    public Animator blackBarsAnim;
    [Header("-Prefabs-")]
    public GameObject bossB;

    private float transistionSpeed = 2f;
    private Transform currentCameraTrans;
    private Transform playerTrans;
    private ThirdPersonController tpc;
    private CameraPanTrigger cpt;
    private CloseDoor cameraPT;


    [Header("-Transforms-")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform cameraPosDefault, overShoulderRight, overShoulderLeft, behindLookup;
    [SerializeField] private Transform cameraTargetDefault, cameraTargetFront, cameraTargetUp;

    public CameraState _cameraState;
    public CameraState cameraState {
        get
        {
            return _cameraState;
        }
        set
        {
            _cameraState = value;

            switch (_cameraState)
            {
                case CameraState.Default:
                    currentCameraTrans = cameraPosDefault;
                    SetCameraTarget(cameraTargetDefault);
                    CameraLock();
                    tpc.canMove = true;
                    StartCoroutine("Blackbars");
                    break;
                case CameraState.Left:
                    currentCameraTrans = overShoulderLeft;
                    tpc.canMove = false;
                    tpc.canLookAround = false;
                    break;
                case CameraState.Right:
                    currentCameraTrans = overShoulderRight;
                    tpc.canMove = false;
                    tpc.canLookAround = false;
                    break;
                case CameraState.Behind:
                    currentCameraTrans = behindLookup;
                    SetCameraTarget(cameraTargetUp);
                    CameraLock();
                    break;
                case CameraState.Pan:
                    tpc.canMove = false;
                    tpc.canLookAround = false;
                    break;
                case CameraState.Static:
                    currentCameraTrans.position = panTarget.position + (offset + new Vector3(0f, 1f, -2f));
                    SetCameraTarget(panTarget.transform);
                    StartCoroutine("StaticPause");
                    tpc.canMove = false;
                    tpc.canLookAround = false;
                    break;
            }
        } 
    }
    [HideInInspector] public Transform currentCameraTarget;

    void Start()
    {
        tpc = FindObjectOfType<ThirdPersonController>();
        cpt = FindObjectOfType<CameraPanTrigger>();
        cameraPT = FindObjectOfType<CloseDoor>();

        playerTrans = tpc.transform;
        transform.position = playerTrans.position + offset;

        cameraTargetDefault.position = playerTrans.position;
        cameraState = CameraState.Default;

    }

    void Update()
    {
        if (cameraState != CameraState.Pan && cameraState != CameraState.Static)
        {
            cameraPosDefault.position = playerTrans.position + offset;

            CameraFollowPlayer();
        }

        if (cameraState == CameraState.Pan)
        {
            PanCameraOver(panHeight);
        }
    }

    void CameraLock() {
        if (SceneManager.GetActiveScene().name == "BossRoom" && !cameraPT.door.activeInHierarchy)
        {
            tpc.canLookAround = false;
        }
        else {
            tpc.canLookAround = true;
        }
    }

    void CameraFollowPlayer()
    {
        transform.position = currentCameraTrans.position;
        transform.forward = (currentCameraTarget.position - transform.position).normalized;
    }

    public void SetCameraTarget(Transform target)
    {
        currentCameraTarget = target;
    }

    void PanCameraOver(float panHeight) {

        Vector3 cameraXZ = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetXZ = new Vector3(panTarget.position.x, 0f, panTarget.position.z);

        float distance = Vector3.Distance(cameraXZ, targetXZ);
        float stoppingDistance = 1f;

        blackBarsAnim.SetInteger("blackBarsInt", 1);

        transform.position = Vector3.Slerp(transform.position, new Vector3(panTarget.position.x, panHeight, panTarget.position.z), transistionSpeed * Time.deltaTime);
        if (distance <= stoppingDistance) {
            cameraState = CameraState.Static;
        }
    }

    IEnumerator StaticPause() {

        if (SceneManager.GetActiveScene().name == "BossRoom")
        {
            blackBarsAnim.SetInteger("blackBarsInt", 2);
            bossB.SetActive(true);
            yield return new WaitForSeconds(panPause);
            cameraState = CameraState.Default;
        }
        else {
            blackBarsAnim.SetInteger("blackBarsInt", 2);
            yield return new WaitForSeconds(panPause);
            cameraState = CameraState.Default;
        }
    }

    IEnumerator Blackbars()
    {
        yield return new WaitForSeconds(0.5f);
        blackBarsAnim.SetInteger("blackBarsInt", 3);
        yield return new WaitForSeconds(0.5f);
        blackBarsAnim.SetInteger("blackBarsInt", 0);
        if (SceneManager.GetActiveScene().name == "BossRoom" && bossB.activeSelf == true) {
        
            bossB.GetComponent<BossEnemyBehaviour>().bossState = BossState.Chasing;
        }
    }
}
