using UnityEngine;
using System.Collections;

    public enum TriggerCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    private CameraMovement cameraM;
    [HideInInspector] public bool isTriggered;
    /*[HideInInspector] */public bool activateSwitch;

    [Header("-Event Panning-")]
    public Transform target;
    public int height;
    public int panPause;
    public int animPause;

    [Header("-Trigger Type-")]
    public bool movingPlatform;
    public TriggerCase triggerCase;
    public int numberKey_multi;

    [Header("-Prefabs-")]
    public GameObject objectToTrigger;

    void Start() {
        cameraM = FindObjectOfType<CameraMovement>();
    }

	void Update () {

        //if (isTriggered)
        //{
        //}
        //else
        //{
        //}

        if (!movingPlatform)
        {
            if (activateSwitch)
            {
                if (!isTriggered)
                {
                    if (triggerCase == TriggerCase.Multi)
                    {
                        isTriggered = true;
                        objectToTrigger.GetComponent<MultiSwitchEvent>().actives[numberKey_multi] = true;
                        StartCoroutine("WaitForPan");
                    }
                    else
                    {
                        isTriggered = true;
                        StartCoroutine("WaitForPan");
                        objectToTrigger.GetComponent<DoorEvent>().active = true;
                    }
                }
            }
        }
        else {
            if (activateSwitch)
            {
                if (!isTriggered)
                {
                    isTriggered = true;
                    StartCoroutine("WaitForPan");
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
