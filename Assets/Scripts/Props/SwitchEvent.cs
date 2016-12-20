using UnityEngine;
using System.Collections;

    public enum TriggerCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    private CameraMovement cameraM;
    private GameObject[] buttons;
    [HideInInspector] public bool isTriggered;
    /*[HideInInspector] */public bool switchEventActivate;

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
        //buttons[0] = Resources
    }

	void Update () {

        if (isTriggered) {
            Color colTrig = new Color(0.3f, 0f, 0f, 1f);
            gameObject.GetComponent<Renderer>().material.color = colTrig;
        }
        else {
            Color colNotTrig = new Color(1f, 0f, 0f, 1f);
            gameObject.GetComponent<Renderer>().material.color = colNotTrig;
        }

        if (switchEventActivate)
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

    public IEnumerator WaitForPan() {
        cameraM.panTarget = target;
        cameraM.panHeight = height;
        cameraM.panPause = panPause;
        cameraM.cameraState = CameraState.Pan;
        yield return new WaitForSeconds(animPause);
    }
}
