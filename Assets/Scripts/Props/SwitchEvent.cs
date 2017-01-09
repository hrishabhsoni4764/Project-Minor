using UnityEngine;
using System.Collections;

    public enum TriggerCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    private CameraMovement cameraM;
    [HideInInspector] public bool isTriggered;
    [HideInInspector] public bool activateSwitch;

    [Header("-Event Panning-")]
    public bool willPan;
    public Transform target;
    public int height;
    public int panPause;
    public int animPause;

    [Header("-Trigger Type-")]
    public bool movingPlatform;
    public bool togglePlatform;
    public TriggerCase triggerCase;
    public int numberKey_multi;

    [Header("-Prefabs-")]
    public GameObject objectToTrigger;

    void Start() {
        cameraM = FindObjectOfType<CameraMovement>();
    }

	void Update () {

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
                            objectToTrigger.GetComponent<DoorEvent>().active = true;
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

    public IEnumerator WaitForPan() {
        cameraM.panTarget = target;
        cameraM.panHeight = height;
        cameraM.panPause = panPause;
        cameraM.cameraState = CameraState.Pan;
        yield return new WaitForSeconds(animPause);
    }
}
