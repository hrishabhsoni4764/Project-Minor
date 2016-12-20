using UnityEngine;
using System.Collections;

public class FloorButton : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PushBlock")
        {
            GetComponent<SwitchEvent>().activateSwitch = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PushBlock")
        {
            GetComponent<SwitchEvent>().activateSwitch = false;
        }
    }
}
