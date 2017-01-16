using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    public GameObject objToTp;
    public GameObject tpLoc;

void OnTriggerStay(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        objToTp.transform.position = tpLoc.transform.position;
    }
}

}
