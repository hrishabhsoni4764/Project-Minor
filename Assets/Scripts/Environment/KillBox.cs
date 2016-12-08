using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    void OnCollisionStay (Collision C)
    {
        if (C.collider.GetComponent<Raycasts>() != null)
        {
            C.collider.GetComponent<Raycasts>().Kill();
        }
    }
}
