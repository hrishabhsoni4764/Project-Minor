using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

    void OnCollisionStay (Collision C)
    {
        if (C.collider.GetComponent<YouDead>() != null)
        {
            C.collider.GetComponent<YouDead>().Kill();
        }
    }
}
