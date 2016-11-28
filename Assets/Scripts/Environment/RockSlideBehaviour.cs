using UnityEngine;
using System.Collections;

public class RockSlideBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(Resources.Load("Prefabs/Environment/RockSlideDebris"), transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
            }
            Instantiate(Resources.Load("Prefabs/Environment/Dust"), transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
