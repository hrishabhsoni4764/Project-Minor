using UnityEngine;
using System.Collections;


    public enum TriggerCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    private CameraMovement cameraM;
    [HideInInspector] public bool isTriggered;
    [HideInInspector] public bool activateSwitch;

    [Header("-Event Panning-"), Tooltip("If willPan is enabled, the camera will move towards the target upon triggering this switch")]
    public bool willPan;
    public Transform target;
    public int height;
    public int panPause;
    public int animPause;

    [Header("-Trigger Type-"), Tooltip("Enable movingPlatform if objectToTrigger is a moving platform or enable togglePlatform if objectToTrigger is a toggle plaform")]
    public bool movingPlatform;
    public bool togglePlatform;

    [Header("-Trigger Case-"), Tooltip("If set to Multi, this switch will become one of multiple switches to set objectToTrigger to active")]
    public TriggerCase triggerCase;
    public int numberKey_multi;

    [Header("-Trigger Amount-"),Tooltip("If enabled, will set all the children of the objectToTrigger to active (Must have Trigger Case set to Single)")]
    public bool triggerMultiple;

    [Header("-Prefabs-")]
    public GameObject objectToTrigger;

    public bool somenelse;

    void Start() {
        cameraM = GameManager.instance.cameraM;
    }

    void Update()
    {

        if (!triggerMultiple)
        {
            if (!movingPlatform)
            {
                if (!togglePlatform)
                {
                    if (activateSwitch)
                    {
                        if (!isTriggered)
                        {
                            if (triggerCase == TriggerCase.Multi)
                            {
                                isTriggered = true;
                                objectToTrigger.GetComponent<MultiSwitchEvent>().actives[numberKey_multi] = true;
                                if (willPan)
                                {
                                    StartCoroutine("WaitForPan");
                                }
                            }
                            else
                            {
                                isTriggered = true;
                                if (willPan)
                                {
                                    StartCoroutine("WaitForPan");
                                }
                                if (!somenelse)
                                {
                                    objectToTrigger.GetComponent<DoorEvent>().active = true;
                                }
                                else
                                {
                                    objectToTrigger.GetComponent<DoorEvent>().active2 = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (activateSwitch)
                    {
                        if (willPan)
                        {
                            StartCoroutine("WaitForPan");
                        }
                        objectToTrigger.GetComponent<TogglePlatform>().isHit = true;
                        activateSwitch = false;
                    }
                }
            }
            else {
                if (activateSwitch)
                {
                    if (!isTriggered)
                    {
                        isTriggered = true;
                        if (willPan)
                        {
                            StartCoroutine("WaitForPan");
                        }
                        objectToTrigger.GetComponent<MovingPlatform>().active = true;
                    }
                }
            }
        }
        else
        {
            if (activateSwitch)
            {
                if (!isTriggered)
                {
                    isTriggered = true;
                    if (willPan)
                    {
                        StartCoroutine("WaitForPan");
                    }
                    MovingPlatform[] childrenM = objectToTrigger.GetComponentsInChildren<MovingPlatform>();
                    TogglePlatform[] childrenT = objectToTrigger.GetComponentsInChildren<TogglePlatform>();
                    DoorEvent[] childrenD = objectToTrigger.GetComponentsInChildren<DoorEvent>();
                    foreach (MovingPlatform item in childrenM)
                    {
                        item.active = true;
                    }
                    foreach (TogglePlatform item in childrenT)
                    {
                        item.isHit = true;
                    }
                    foreach (DoorEvent item in childrenD)
                    {
                        item.active = true;
                    }

                }
            }
        }
    }

    public IEnumerator WaitForPan() {
        cameraM.panTarget = target;
        cameraM.panHeight = height;
        cameraM.panPause = panPause;
        cameraM.cameraState = CameraState.Pan;
        yield return new WaitForSeconds(animPause);
    }
}
