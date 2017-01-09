using UnityEngine;
using System.Collections;

public class FloorButton : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            GetComponent<SwitchEvent>().activateSwitch = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            GetComponent<SwitchEvent>().activateSwitch = false;
        }
    }
}
