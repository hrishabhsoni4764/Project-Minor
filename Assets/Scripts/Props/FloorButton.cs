using UnityEngine;
using System.Collections;

public class FloorButton : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PushBlock")
        {
            GetComponent<Animator>().SetInteger("pushFloorButton", 1);
            GetComponent<SwitchEvent>().switchEventActivate = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PushBlock")
        {
            GetComponent<Animator>().SetInteger("pushFloorButton", 0);
        }
    }
}
