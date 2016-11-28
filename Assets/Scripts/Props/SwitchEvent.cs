using UnityEngine;
using System.Collections;

    public enum TriggerCase { Single, Multi }
public class SwitchEvent : MonoBehaviour {

    [HideInInspector] public bool switchEventActivate;

    [Header("Trigger Type")]
    public TriggerCase triggerCase;
    public int numberKey_multi;
    [Header("Prefabs")]
    public GameObject objectToTrigger;
	
	void Update () {
        if (switchEventActivate) {
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

}
