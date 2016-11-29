using UnityEngine;
using System.Collections;

    public enum TriggerCase { Single, Multi }
    public enum ObjectCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    [HideInInspector] public bool switchEventActivate;

    [Header("Trigger Type")]
    public TriggerCase triggerCase;
    public int numberKey_multi;
    [Header("Prefabs")]
    public ObjectCase objectCase;
    public GameObject objectToTrigger;
    public GameObject objectToTrigger2;
	
	void Update () {
        if (switchEventActivate) {
            switch (triggerCase)
            {
                case TriggerCase.Single:
                    switch (objectCase)
                    {
                        case ObjectCase.Single:
                            objectToTrigger.GetComponent<DoorEvent>().active = true;
                            break;
                        case ObjectCase.Multi:
                            objectToTrigger.GetComponent<DoorEvent>().active = true;
                            objectToTrigger2.GetComponent<DoorEvent>().active = true;
                            break;
                    }
                    break;
                case TriggerCase.Multi:
                    objectToTrigger.GetComponent<MultiSwitchEvent>().actives[numberKey_multi] = true;
                    break;
            }
        }
	}

}
