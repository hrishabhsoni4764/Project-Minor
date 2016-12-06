using UnityEngine;
using System.Collections;

    public enum TriggerCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    private CameraMovement cameraM;
    private bool isTriggered;
    [HideInInspector] public bool switchEventActivate;

    [Header("-Event Panning-")]
    public Transform target;
    public int height;
    public int panPause;
    public int animPause;

    [Header("-Trigger Type-")]
    public TriggerCase triggerCase;
    public int numberKey_multi;

    [Header("-Prefabs-")]
    public GameObject objectToTrigger;

    void Start() {
        cameraM = FindObjectOfType<CameraMovement>();
    }

	void Update () {
        if (switchEventActivate) {
            if (!isTriggered)
            {
                isTriggered = true;
                StartCoroutine("WaitForPan");
            }
        }
	}

    IEnumerator WaitForPan() {
        cameraM.panTarget = target;
        cameraM.panHeight = height;
        cameraM.panPause = panPause;
        cameraM.cameraState = CameraState.Pan;
        yield return new WaitForSeconds(animPause);
        switch (triggerCase)
        {
            case TriggerCase.Single:
                objectToTrigger.GetComponent<DoorEvent>().active = true;
                break;
            case TriggerCase.Multi:
                objectToTrigger.GetComponent<MultiSwitchEvent>().actives[numberKey_multi] = true;
                break;
        }
    }

}
